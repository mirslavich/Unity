using System;
using UnityEngine;

public class NinjaFlip : MonoBehaviour
{ 
    private SpriteRenderer ninja;
    public static Action direction;

    void Start()
    {
        ninja = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount>0)
        {
            ninja.flipX = !ninja.flipX;
            direction?.Invoke();
        }
    }
}
