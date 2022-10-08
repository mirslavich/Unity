using DefaultNamespace;
using UnityEngine;

public class DamagingObstacle : MonoBehaviour
{
    [SerializeField] private int demage = 2;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            var playerBody = col.gameObject.GetComponent<Rigidbody2D>();
            playerBody.AddForce(new Vector2(-1.0f,0.0f)*20,ForceMode2D.Impulse);
            Debug.Log("Hit");
            GlobalEventManager.GetDamage(demage);
        }
    }
}
