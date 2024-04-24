using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rd2D;
    private Vector2 move;
    public float moveSpeed = 10f;
    public float jumpPower = 100f;

    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
    }// Start
    void Update()
    {
        move = new Vector2( Input.GetAxisRaw("Horizontal")  , 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rd2D.AddForce( Vector2.up * jumpPower );
        }
    }// Update
    private void FixedUpdate()
    {
        rd2D.AddForce( move * moveSpeed );
        
        //rd2D.MovePosition( rd2D.position + (move * moveSpeed) );
 
    }//FixedUpdate
    
}
