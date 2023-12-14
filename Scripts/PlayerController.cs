using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public bool isGrounded;
    public Animator myAnim;

    private float inputX;
    private Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        if (inputX != 0) {
            MovePlayer();
            myAnim.SetBool("isRunning", true);
        } else {
            myAnim.SetBool("isRunning", false);
        }

        // Rotate the character depending on the direction of the movement.
        if (inputX > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (inputX < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void MovePlayer()
    {
        myRb.position += Vector2.right * moveSpeed * inputX * Time.deltaTime;
    }

    void Jump()
    {
        myRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        myAnim.SetTrigger("Jumped");
    }
}
