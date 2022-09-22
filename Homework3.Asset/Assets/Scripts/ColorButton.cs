using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorButton : MonoBehaviour
{
    public Action<Color> OnClickColorEvent;
    [SerializeField] private Color color;

    public void OnClick()
    {
        OnClickColorEvent(color);
    }
}
