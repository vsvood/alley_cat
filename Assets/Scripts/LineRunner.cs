using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRunner : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform t;
    bool running = false;
    public float dirX = -1;
    public float speed = 10;
    public float delay = 5;
    public float timeout = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
        StartCoroutine(Init());
    }

    // Update is called once per frame
    void Update()
    {

        if (running) {
            if (dirX * t.localPosition.x > 14.5) {
                dirX = dirX * -1;
                sr.flipX = !sr.flipX;
                running = false;
                rb.velocity = new Vector2(0, rb.velocity.y);
                StartCoroutine(Wait());
            } else {
                rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
            }
        }

    }
    
    IEnumerator Init()
    {
        yield return new WaitForSeconds(delay);
        running = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeout);
        running = true;
    }
}
