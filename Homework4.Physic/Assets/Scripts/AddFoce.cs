using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFoce : MonoBehaviour
{
    private Rigidbody body;
    void Start()
    {
        body=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            body.AddForce(Vector3.up*0.03f,ForceMode.Impulse);
       
    }
}
