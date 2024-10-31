using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpRate;
    public SpriteRenderer sr;
    public AudioClip JumpClip;
    public AudioClip winClip;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal < 0)
        {
            sr.flipX = true;
        }
        else if (moveHorizontal > 0)
        {
            sr.flipX = false;  
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {  
            rb.velocity = new Vector2(moveHorizontal * speed, jumpRate);
            AudioManager.PlaySound(JumpClip);
        }
        else
        {
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dead Zone"))
        {
            Debug.Log("YOU LOSE!");
        }  else if (collision.CompareTag("Cherry"))
        {
            Debug.Log("YOU WIN!");
            AudioManager.PlaySound(winClip);
        }
    }
    
}
