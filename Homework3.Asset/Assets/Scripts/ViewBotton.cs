using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class ViewBotton : MonoBehaviour
{
    public Action<Button> SomeButtonEvent;
    [SerializeField] private Button button;

    public void OnClick()
    {
        SomeButtonEvent(button);
    }
}
  
