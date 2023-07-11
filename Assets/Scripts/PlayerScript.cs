using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameManager gm;
    public float jumpForce;
    public BoxCollider2D exColl;
    float velocityY;
    BoxCollider2D coll;
    Rigidbody2D rb;

    public LayerMask groundLayer;
    public Transform groundCheck;

    public float speed;
    public int timer = 0;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        gm = gm.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        velocityY = rb.velocity.y;

        if (exColl.enabled == false){
            while (timer != 100){
                timer++;
            }
        }

        if(timer == 100){
            exColl.enabled = true;
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Jump();
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colls = Physics2D.OverlapCircleAll(groundCheck.position, 0.15f, groundLayer);
        if (colls.Length > 0 && velocityY == 0)
        {
            isGrounded = true;
            if (colls[0].gameObject.tag == "Platform")
            {
                Debug.Log("Platform Detected");
                gm.jumpedPlatforms++;
                gm.Points += 10;
            }

            //if (colls[0].gameObject.tag == "Gold Platform")
            //{
            //    Debug.Log("Platform Detected");
            //    gm.jumpedPlatforms++;
            //    gm.Points += 50;
            //}
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            exColl.enabled = false;
        }
    }

    // Controls Logic
    void moveLeft(){
        rb.velocity = Vector2.left * jumpForce;
    }
    
    void moveRight(){
        rb.velocity = Vector2.right * jumpForce;
    }

    void StopMoving(){
        rb.velocity = Vector2.zero;
    }
}
