using System;
using DefaultNamespace;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight = true;

    private Animator animate;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();
        GlobalEventManager.OnDead.AddListener(Die);
        moveSpeed = 35f;
        jumpForce = 15f;
        isJumping = false;
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        animate.SetFloat("Speed",Mathf.Abs(moveHorizontal));
        if (moveHorizontal>0 && !facingRight)
        {
            Flip();
        }
        else if(moveHorizontal<0 && facingRight)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        if (moveHorizontal>0.1f||moveHorizontal<0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal*moveSpeed,0f)*Time.deltaTime,ForceMode2D.Impulse);
        }
        
        if (!isJumping && moveVertical>0.1f)
        {
            rb.AddForce(new Vector2(0f,moveVertical*jumpForce),ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Platform")
        {
            isJumping = false;
            animate.SetBool("isJumping",false);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag=="Platform")
        {
            isJumping = true;
            animate.SetBool("isJumping",true);
        }
    }
    public void GetDamage()
    {
        throw new NotImplementedException();
    }
    void Flip()
    {
        facingRight = !facingRight;
        var currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
    private void Die(bool isDead)
    {
        Destroy(gameObject);
        LevelManager.instance.Respawn();
    }
}



