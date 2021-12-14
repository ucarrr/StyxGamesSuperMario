using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PlayerMovement : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1750;
    private float moveX;
    public bool isGrounded;

    
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

     

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Succeed");
        }
    }
    
    void PlayerRaycast()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (hitUp.collider != null && hitUp.distance < 0.9f && hitUp.collider.tag == "brickBlock")
        {
            Destroy(hitUp.collider.gameObject);
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * 700);
        }
        if (hitUp.collider != null && hitUp.distance < 0.9f && hitUp.collider.tag == "questionBlock")
        {
            Destroy(hitUp.collider.gameObject);
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1000);
            Player_Score.playerScore += 10;
        }


        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (hitDown.collider != null && hitDown.distance < 0.98f && hitDown.collider.tag == "Enemy")
        {
             GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
            Destroy(hitDown.collider.gameObject);
            Player_Score.playerScore += 10;
        }

        if (hitDown.collider != null && hitDown.distance < 0.97f && hitDown.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
    }
}