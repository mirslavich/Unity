using UnityEngine;
using DefaultNamespace;

public class Enemy : Entity
{
   [SerializeField] private int demage=1;
   private Vector3 direction;
   private SpriteRenderer spriteRenderer;
   private Rigidbody2D body;

   private void Awake()
   {
      spriteRenderer = GetComponentInChildren<SpriteRenderer>();
   }

   private void Start()
   {
      direction = transform.right;
   }

   private void Update()
   {
      Move();
   }

   private void Move()
   {
      var colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * direction.x * 0.7f, 0.4f);
      if (colliders.Length > 1)
      {
         direction *= -1f;
      }
      transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
     spriteRenderer.flipX = direction.x < 0.0f;
   }

   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.gameObject.tag=="Player")
      {
         Die();
         GlobalEventManager.GetDamage(demage);
      }
   }
}
