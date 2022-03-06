using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameManager gm; 
    BoxCollider2D coll;
    Rigidbody2D rb;


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
        
    }

    
    void OnCollisionEnter2D(Collision2D other){
        if(gameObject.tag == "Player"){
            Debug.Log("Player Detected");
            if(other.gameObject.tag == "Platform"){
                Debug.Log("Platform Detected");
                rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
                gm.jumpedPlatforms++;
                gm.Points += 10;
                //Destroy(other.gameObject);
            }
        }
    }
}
