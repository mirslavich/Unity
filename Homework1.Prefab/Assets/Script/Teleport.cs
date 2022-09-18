using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Vector3 minValue = new Vector3(-20.0f, 0.0f, -20.0f);

    [SerializeField]
    private Vector3 maxValue = new Vector3(20.0f, 20.0f, 20.0f);

    [SerializeField]
    private int timer = 1;

    void Start()
    {
          InvokeRepeating(nameof(DoRandomTeleport), 2f, timer);
    }

    void Update()
    {
        
    }

    private void DoRandomTeleport()
    {
        transform.position = new Vector3(Random.Range(minValue.x, maxValue.x), Random.Range(minValue.y, maxValue.y), Random.Range(minValue.z, maxValue.z));

    }
}
