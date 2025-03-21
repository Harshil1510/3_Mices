using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isJumping;
    public float rotationSpeed = 200f;
    public float moveSpeed = 5f;

    private bool moveLeft, moveRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
    }
    public void Jump()
    {
        if (!isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
    }
    private void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            rb.velocity = new Vector2(speed * move, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, move < 0 ? 180 : 0, 0);
        }
        else if (moveLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }
    }
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        transform.position += movement * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        isJumping = false;
    }
}
