using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 direction;

    [SerializeField] private float speadRotate;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(direction*speadRotate*Time.deltaTime);
    }

    
}
