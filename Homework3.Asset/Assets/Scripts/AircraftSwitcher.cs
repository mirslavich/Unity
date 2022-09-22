using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> listAircrafts;
    private int indexCurrentAircraft = 0;
    [SerializeField] private List<ColorButton> listColorButtons;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private float speed = 5;
    [SerializeField] private Camera miniMapCamera;
    [SerializeField] private List<ViewBotton> nameViewBottons;
    private GameObject emtyGameObject;
    private string lastInputButton="Up";

    private void Start()
    {
        listAircrafts.ForEach(a => a.SetActive(false));
        listColorButtons.ForEach(b => b.OnClickColorEvent += ChangeColor);
        listAircrafts[0].SetActive(true);
        rightButton.onClick.AddListener(delegate
        {
            var temp = indexCurrentAircraft;
            if (indexCurrentAircraft + 1 > listAircrafts.Count - 1)
            {
                indexCurrentAircraft = 0;
            }
            else
            {
                indexCurrentAircraft += 1;
            }
            OffAircraft(temp, indexCurrentAircraft);
        });
        leftButton.onClick.AddListener(delegate
        {
            var temp = indexCurrentAircraft;
            if (indexCurrentAircraft - 1 < 0)
            {
                indexCurrentAircraft = listAircrafts.Count - 1;
            }
            else
            {
                indexCurrentAircraft -= 1;
            }
            OffAircraft(temp, indexCurrentAircraft);
        });
        nameViewBottons.ForEach(n => n.SomeButtonEvent += ChangePositionMiniMapCamera);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            listAircrafts[indexCurrentAircraft].transform.Rotate(0, touch.deltaPosition.x / -speed, 0, Space.Self);
        }
    }

    private void ChangeColor(Color color)
    {
        listAircrafts[indexCurrentAircraft].GetComponent<Renderer>().material.color = color;
    }

    private void OffAircraft(int temp, int newIndex)
    {
        listAircrafts[temp].SetActive(false);
        listAircrafts[temp].GetComponent<Renderer>().material.color = Color.white; //I like it better with color reset
        listAircrafts[newIndex].SetActive(true);
        if (lastInputButton != null)
        {
            FindChildObjectForCamera(lastInputButton);
        }
    }

    private void ChangePositionMiniMapCamera(Button nameButton)
    {
        switch (nameButton.name)
        {
            case "Up":
                FindChildObjectForCamera(nameButton.name);
                break;
            case "Down":
                FindChildObjectForCamera(nameButton.name);
                break;
            case "Left":
                FindChildObjectForCamera(nameButton.name);
                break;
            case "Face":
                FindChildObjectForCamera(nameButton.name);
                break;
            default:
                Debug.Log("Not found nameButton button");
                Application.Quit();
                return;
        }
    }

    private void FindChildObjectForCamera(String name)
    {
        emtyGameObject = listAircrafts[indexCurrentAircraft].transform.Find(name).gameObject;
        if (emtyGameObject == null)
        {
            Debug.Log("NULL");
            Application.Quit();
        }
        miniMapCamera.transform.SetParent(emtyGameObject.transform, false);
        lastInputButton = name;
    }
}
