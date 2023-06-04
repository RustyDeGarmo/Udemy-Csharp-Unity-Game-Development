using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float turnSpeed = 50f;
    float localTime;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        localTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        //thrust controls

        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * localTime);
        }
    }

    void ProcessRotation()
    {
        //rotation controls

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(Vector3.forward * turnSpeed * localTime);
        }else if(Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(Vector3.back * turnSpeed * localTime);
        }
    }

}
