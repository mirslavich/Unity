using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] float positionShiftX=23.2f;
    [SerializeField] float speed;
    private Vector2 startPosition;
    private Vector2 endPosition;
    float distance; 
    float time;
    private float currentTime;

    private void Start()
    {
        if (GetComponent<Transform>()==null)
        {
            Debug.Log("Null start position");
            return;
        }
        startPosition = GetComponent<Transform>().position;
        NinjaFlip.direction += ChangeDirection;
        endPosition = new Vector2(transform.position.x+positionShiftX, transform.position.y);
         distance = Vector2.Distance(startPosition, endPosition);
         time = distance / speed;
    }
    
    private void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector2.Lerp(startPosition, endPosition,currentTime/time);
        if (currentTime>=time)
        {
            currentTime = 0;
        }
    }

    private void ChangeDirection()
    { 
        positionShiftX = -positionShiftX;
        startPosition = GetComponent<Transform>().position;
        endPosition = new Vector2(transform.position.x+positionShiftX, transform.position.y);
    }
}

