using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float despawnCountdonw;

    public float arrowDespawnTime;
    
    public float arrowDamage = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         despawnCountdonw += Time.deltaTime;

        if (despawnCountdonw >= arrowDespawnTime)
            Destroy(gameObject);
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyArrow"))
        {
            col.gameObject.GetComponent<PlayerMovement>().health -= arrowDamage;
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Arrow"))
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();

            if (!enemy.isLastStage == true)
            {
                enemy.enemyHp -= arrowDamage;
            }
                
            Destroy(gameObject);
        }

    }
}
