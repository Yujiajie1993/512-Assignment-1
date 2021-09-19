using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransfrom;
    public Transform arms;
    public CharacterController playerController;

    // rotation
    public float rotationSensitivity = 600f;
     private float rotationX = 0f;
    private float rotationY = 0f;

    // ground test
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isGround = true;

    // gravity and jump
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // move
    private Vector3 vVelocity;  // vertical velocity
    private Vector3 hVelocity;  // horizontal velocity
    private const float lowSpeed = 4;
    private const float highSpeed = 7;

    // animation
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.identity;
    }


    void Move_Update()
    {
        // gravity and detect if player jump
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGround && vVelocity.y < 0)
        {
            vVelocity.y = -2;
        }

        vVelocity.y += gravity * 1.8f * Time.deltaTime;
        playerController.Move(vVelocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            vVelocity.y =  Mathf.Sqrt(jumpHeight * -2 * gravity);
        } 


        // detect if player walk or run
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            hVelocity = playerTransfrom.forward * Input.GetAxis("Vertical") + 
                        playerTransfrom.right * Input.GetAxis("Horizontal");

            if(Input.GetKey(KeyCode.LeftShift))
            {
                playerAnimator.SetBool("Run", true);
                playerAnimator.SetBool("Walk", false);
                playerController.Move(hVelocity * highSpeed * Time.deltaTime);
            }
            else if(!Input.GetKey(KeyCode.LeftShift))
            {
                playerAnimator.SetBool("Walk", true);
                playerAnimator.SetBool("Run", false);
                playerController.Move(hVelocity * lowSpeed * Time.deltaTime);
            }

        }
        else if(!(Input.GetKey("w") && Input.GetKey("a") && Input.GetKey("s") && Input.GetKey("d")))
        {
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Run", false);
        }
    }

    void View_Update()
    {
        // rotate around y axis
        rotationY += Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime;

        // rotate player
        playerTransfrom.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // rotate around x axis
        rotationX += Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  

        // rotate camera
        //transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0f);
        transform.localRotation = Quaternion.Euler(-rotationX, 0, 0f);
        arms.transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0f);
    }
    void Fire_Update()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        View_Update();
        Move_Update();
    }
}
