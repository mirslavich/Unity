using DefaultNamespace;
using UnityEngine;

public class FruitFlyController : MonoBehaviour
{
    private bool moveToTheSecond;
    private LivesBarController livesBarController;
    private Vector3 theFirstPoint;
    private Vector3 theSecondPoint;
    [SerializeField] private float speed;

    private void Start()
    {
        theFirstPoint = transform.position; 
        theSecondPoint = new Vector3(theFirstPoint.x, theFirstPoint.y + 1f, theFirstPoint.z);
        moveToTheSecond = true;
        livesBarController = GameObject.Find("Backgraund").GetComponent<LivesBarController>();
    }
   void Update()
    {
        if (moveToTheSecond&& gameObject != null)
        {
            MoveToPoint(theSecondPoint);
        }
        else
        {
            MoveToPoint(theFirstPoint);
        }
    }
    private void MoveToPoint(Vector3 somePoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, somePoint, speed * Time.deltaTime);
        if (transform.position==somePoint)
        {
            moveToTheSecond = !moveToTheSecond;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            GlobalEventManager.SendLivesAdded();
            Destroy(gameObject);
        }
    }
}
