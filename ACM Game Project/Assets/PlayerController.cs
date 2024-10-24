using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");

        if(MoveHorizontal < 0)
        {
            sr.flipX = true;
        }   else if(MoveHorizontal > 0)
        { 
                sr.flipY=true;
        }

        rb.velocity = new Vector2(MoveHorizontal * speed, rb.velocity.y);
    }
}
