using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2D;
    SpriteRenderer sprite_ren;

    bool isGrounded;
    [SerializeField]
    Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite_ren = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }

        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(2, rb2D.velocity.y);
            animator.Play("player_run");
            sprite_ren.flipX = false;
        }

        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-2, rb2D.velocity.y);
            animator.Play("player_run");
            sprite_ren.flipX = true;
        }

        else
        {
            animator.Play("player_idle");
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if(Input.GetKey("space") && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 2);
            animator.Play("player_jump");
        }
    }
}
