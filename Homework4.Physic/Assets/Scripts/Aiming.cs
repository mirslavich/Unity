using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera aimCamera;
    [SerializeField] private Image aim;

    void Start()
    {
        aimCamera.enabled = false;
        aim.enabled = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aim.enabled = true;
            mainCamera.enabled = false;
            aimCamera.enabled = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            aim.enabled = false;
            mainCamera.enabled = true;
            aimCamera.enabled = false;
            
        }
    }
}
