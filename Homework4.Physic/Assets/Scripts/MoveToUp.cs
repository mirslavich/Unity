using UnityEngine;

public class MoveToUp : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] private float speed;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (body == null)
        {
            Debug.Log("Some body is NULL ");
        }
    }

    void FixedUpdate()
    {
        body.GetComponent<Rigidbody>().AddForce(Vector3.up.normalized*speed,ForceMode.Impulse);
    }
}
