using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpRate;
    public SpriteRenderer sr;
    public AudioClip JumpClip;
    public AudioClip winClip;
    public int maxJumps;
    private int jumpCount;
    private Animator animator;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpCount = maxJumps;
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(moveHorizontal));

        if (moveHorizontal < 0)
        {
            sr.flipX = true;
        }
        else if (moveHorizontal > 0)
        {
            sr.flipX = false;  
        }

        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.Space))
        {  
            rb.velocity = new Vector2(moveHorizontal * speed, jumpRate);
            jumpCount--;
            AudioManager.PlaySound(JumpClip);
            
        }
        else
        {
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            Debug.Log("Hit ground");
            jumpCount = maxJumps;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dead Zone"))
        {
            Debug.Log("YOU LOSE!");
            SceneManager.LoadScene("Main Menu");

        }  else if (collision.CompareTag("Cherry"))
        {
            Debug.Log("YOU WIN!");
            AudioManager.PlaySound(winClip);
        }
    }
    
}
