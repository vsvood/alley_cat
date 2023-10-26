using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10) {
            transform.position = new Vector2(0, -8);
        }

        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") & grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 15);
        }

        if (dirX > 0) {
            sr.flipX = false;
            animator.SetBool("running", true);
        } else if (dirX < 0) {
            sr.flipX = true;
            animator.SetBool("running", true);
        } else {

            animator.SetBool("running", false);
        }
    }
}
