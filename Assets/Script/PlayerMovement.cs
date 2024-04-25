using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rd2D;
    private Vector2 move;
    public float moveSpeed = 10f;
    public float jumpPower = 100f;

    public float health = 100f;
    public float maxHealth = 100f;

    

    public TextMeshProUGUI playerHealth;
    

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
        
        playerHealth.text = $"<color=black>Player Health</color> <color=#E41B17>{health}</color>";
        if (health <= 0)
        {
            SceneManager.LoadScene (sceneName:"EndCredit");
        }
        //rd2D.MovePosition( rd2D.position + (move * moveSpeed) );

    }//FixedUpdate

    
}
