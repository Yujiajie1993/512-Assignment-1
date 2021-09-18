using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransfrom;
    public CharacterController playerController;

    public float rotationSensitivity = 600f;

    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isGround = true;

    private float rotationX = 0f;
    private float rotationY = 0f;


    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private Vector3 velocity;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Move_Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2;
        }

        velocity.y += gravity * 1.8f * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y =  Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        move = playerTransfrom.forward * Input.GetAxis("Vertical") + playerTransfrom.right * Input.GetAxis("Horizontal");
        playerController.Move(move / 20);
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
    }

    // Update is called once per frame
    void Update()
    {
        

        View_Update();
        Move_Update();
    }
}
