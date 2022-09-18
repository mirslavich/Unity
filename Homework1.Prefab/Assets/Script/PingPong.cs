using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PingPong : MonoBehaviour
{
    [SerializeField]
    private Vector3 theFirstPoint; 
    [SerializeField]
    private Vector3 theSecondPoint;
    private Vector3 thePoint;
    [SerializeField]
    private float speed = 2f;

    private bool moveToTheSecond;

    void Start()
    {
        transform.position = theFirstPoint;
        moveToTheSecond = true;
    }

    void Update()
    {
        if (moveToTheSecond)
        {
            MoveToPoint(theSecondPoint);
        }
        else
        {
            MoveToPoint(theFirstPoint);
        }
    }

    private void MoveToPoint(Vector3 somePoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, somePoint, speed * Time.deltaTime);
        if (transform.position==somePoint)
        {
            moveToTheSecond = !moveToTheSecond;
        }
    }
}
