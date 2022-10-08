using UnityEngine;

public class Boss : Entity
{
    [SerializeField] private int lives = 2;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Player")
        {
           Debug.Log("Boss");
            lives--;
        }

        if (lives < 1)
        {
            Die();
        }
    }
}
