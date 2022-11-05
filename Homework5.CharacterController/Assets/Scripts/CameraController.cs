using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private Transform _player;
   [SerializeField] private float _smoothSpeed = 1000f;
   [SerializeField] private float _rotationSpeed=4f;
   [SerializeField] private Transform _lookAt;
   private float _lookDown = 25;
   private float _lookUp = -15;
   private Vector3 _velocity;
   [SerializeField] private UIButtonInfo _buttonJoystikUI; 
   [SerializeField] private UIButtonInfo _buttonJumpUI;

   private void Update()
   {
      transform.position = Vector3.SmoothDamp(transform.position,_lookAt.position,ref _velocity,0f,_smoothSpeed,Time.deltaTime);
      RotateVerticalAxics();
   }

   private void RotateVerticalAxics()
   {
      if (!_buttonJoystikUI.isDown &&  !_buttonJumpUI.isDown && Input.touchCount > 0)
      {
         var touch = new List<Touch>(Input.touches).Find(x => x.position.x > Screen.height / 2);
         var mouseY = touch.deltaPosition.y / 3.0f * _rotationSpeed * Time.deltaTime;
         var xRotation = transform.rotation.eulerAngles.x;
         if (xRotation>180)
         {
            xRotation -= 360;
         }
         if (xRotation>_lookUp && xRotation<_lookDown)
         {
            transform.Rotate(mouseY,0f,0f);
         }
      }
      else
      { 
         transform.LookAt(_player);
      }
   }
}
