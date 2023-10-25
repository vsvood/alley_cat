using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if  (collision.gameObject.CompareTag("killer")) {
            Die();
        } else if (collision.gameObject.CompareTag("prize")) {
            Win();
        }
    }

    void Die() {
        myText.text = "YOU LOSE!";
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetBool("hurt", true);
        StartCoroutine(Wait());
    }

    void Win() {
        myText.text = "YOU WIN!";
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetBool("hurt", true);
        StartCoroutine(Wait());
    }

    void RestartLevel() {
        myText.text = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        RestartLevel();
    }
}
