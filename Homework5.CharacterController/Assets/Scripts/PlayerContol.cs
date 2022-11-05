using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContol : MonoBehaviour
{
    [SerializeField]private Button _jumpButton;
    [SerializeField]private FixedJoystick _joystick;
    private float _gravity = -9.81f;
    [SerializeField]private float _speed = 5.0f;
    private float _jumpSpeed = 7f;
    [SerializeField]private Transform _transformCamera;
    private float _speedY;
    private bool _isJumping;
    private CharacterController _controller;
    private bool _inputJupm;

    private CharacterController Controller { get { return _controller = _controller ?? GetComponent<CharacterController>(); } }

    void Start()
    {
        _jumpButton.onClick.AddListener(delegate { _inputJupm = true; });
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var movementDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        var magnitude = Math.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection = Quaternion.AngleAxis(_transformCamera.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        var velocity = movementDirection * magnitude * _speed;
        velocity.y = _speedY;
        movementDirection.Normalize();
        Controller.Move(velocity * Time.deltaTime);
        if (_joystick.Horizontal!=0 || _joystick.Vertical!=0)
        {
            transform.rotation=Quaternion.LookRotation(movementDirection);
        }
    }
    private void Jump()
    {
        if (_inputJupm&&!_isJumping)
        {
            _isJumping = true;
            _speedY += _jumpSpeed;
            _inputJupm = false;
        }
        if (!Controller.isGrounded)
        {
            _speedY += _gravity * Time.deltaTime;
        }
        else if(_speedY<0f)
        {
            _speedY = 0;
        }
        if (_isJumping&&_speedY<0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,Vector3.down,out hit,2f,LayerMask.GetMask("Graund")))
            {
                _isJumping = false;
            }
        }
    }
}
