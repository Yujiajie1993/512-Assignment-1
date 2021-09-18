using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.0f;
    public float accuracy = 0.01f;
    public Transform goal;


    // test
    public Transform fuel;



    // Start is called before the first frame update
    void Start()
    {
        //this.transform.LookAt(goal.position);
        Vector3 tF = this.transform.up;
        Vector3 fD = fuel.transform.position - this.transform.position;

        Debug.Log("Unity Angle: " + Vector3.Angle(tF, fD));

        float unityAngle = Vector3.SignedAngle(tF, fD, this.transform.forward);
        Debug.Log("Unity unityAngle: " + unityAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = goal.position - this.transform.position;
        // Debug.DrawRay(this.transform.position, direction, Color.red);
        // if(direction.magnitude > accuracy)
        //     this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
