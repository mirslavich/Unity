using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]
    private float scaleLimit = 30.0f;

    private float scaleValue = 0.0f;

    [SerializeField] private float scaleSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
       DoScale();
    }

    private void DoScale()
    {

        if (scaleValue < scaleLimit)
        {
            scaleValue += Time.deltaTime * scaleSpeed;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
    }

}
