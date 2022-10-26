using UnityEngine;

public class PlayerControllerIsometric : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    private Rigidbody2D _rb;
    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        if (_rb==null||_playerAnimation==null)
        {
            Debug.Log("Component is null");
        }
    }

    private void FixedUpdate()
    {
        var currentPos = _rb.position;
        var movement = GatherInput() * movementSpeed;
        var newPos = currentPos + movement * Time.fixedDeltaTime;
        _playerAnimation.SetDirection(movement);
        _rb.MovePosition(newPos);
    }

    private Vector2 GatherInput()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        return inputVector;
    }
}
