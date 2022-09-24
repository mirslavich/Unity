using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEventManager;

public class Robot : MonoBehaviour
{
    [SerializeField]private float movementSpeed;
    [SerializeField]private float rotationSpeed;
    private Rigidbody body;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float sideForse = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForse != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForse, 0.0f);
        }
        float forwardForse = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForse != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForse;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        GlobalEventMagager.SendNameWeapon(other.gameObject);
    }
} 