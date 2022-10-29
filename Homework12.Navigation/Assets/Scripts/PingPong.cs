using UnityEngine;

public class PingPong : MonoBehaviour
{
    private float _distance;
    [SerializeField] private float speed=5;
    [SerializeField] private float shiftX = 15.0f;
    [SerializeField] private float shiftZ = 0.0f;
    private float _time;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + new Vector3(shiftX, 0.0f, shiftZ);
        _distance = Vector3.Distance(_startPosition, _endPosition);
        _time = _distance / speed;
    }

    private void Update()
    {
        var value = Time.time / _time;
        transform.position = Vector3.Lerp(_startPosition, _endPosition, Mathf.PingPong(value, 1f));
    }
}
