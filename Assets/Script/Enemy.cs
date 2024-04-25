using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bullet;
    
    public float reloadingArrow;
    [SerializeField] private float reloadArrowTime = 2.1f;

    private float counterSkill;
    private float counterSkillTime;
    private bool isCounter = false;
    private bool isEndCounter = true;
    public bool isLastStage = false;
    private float ifame;
    private float immortalDooldownTime = 31f;
    
    public float enemyHp = 100f;
    public TextMeshProUGUI enemyHealth;

    public TextMeshProUGUI immortalTxt;
    public TextMeshProUGUI counterTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth.text = $"<color=black>Enemy Health</color> <color=#E41B17>{enemyHp}</color>";
        EnemyStage();
        reloadingArrow += Time.deltaTime;

        CounterSkill();
        
        if (isLastStage == true)
        {
            immortalTxt.gameObject.SetActive(true);
            ifame += Time.deltaTime;
            Debug.Log("ifame" + ifame);
            if (ifame >= 10)
            {
                immortalTxt.gameObject.SetActive(false);
                ifame = 0f;
                isLastStage = false;
            }
        }
        if (isLastStage == false)
        {
            immortalDooldownTime += Time.deltaTime;
        }
        
        if (reloadingArrow >= reloadArrowTime)
        {
            target.transform.position = new Vector2(target.transform.position.x, target.transform.position.y);
            /*Debug.Log(" Player Hit point : " + target.transform.position);*/
            Vector2 projectileV = CalculateProjectile(shootPoint.position, target.transform.position, 1);

            Rigidbody2D spawnBullet = Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, 0, 90));

            spawnBullet.velocity = projectileV;

            reloadingArrow = 0f;
            
            
            /*reloadingText.gameObject.SetActive(false);
            reloadBar.value = reloadingArrow;*/
        }


        Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
        {
            Vector2 distance = targetPoint - origin;

            float velocityX = distance.x / time;
            float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

            Vector2 projecttileVelocity = new Vector2(velocityX, velocityY);

            return projecttileVelocity;


        } //CalculateProjectile
        
    }

    public void EnemyStage()
    {
        if (enemyHp >= 81)
        {
            reloadArrowTime = 2.1f;
        }

        else if (enemyHp >= 61)
        {
            reloadArrowTime = 1.5f;
        }

        else if (enemyHp >= 51)
        {
            reloadArrowTime = 1.3f; 
        }
        
        else if (enemyHp >= 31)
        {
            reloadArrowTime = 1f;
        }
        
        else if (enemyHp >= 21)
        {
            reloadArrowTime = 0.8f;
        }
        
        else if (enemyHp >= 11)
        {
            reloadArrowTime = 0.5f;
        }
        
        else if (enemyHp >= 1 )
        {
            if (immortalDooldownTime >= 30f)
            {
                isLastStage = true;
                immortalDooldownTime = 0f;
            }
            reloadArrowTime = 0.2f;
        }
        else if (enemyHp <= 0 )
        {
            gameObject.SetActive(false);
        }

    }

    public void CounterSkill()
    {
        if (enemyHp <= 70 && isEndCounter == true)
        {
            counterSkill += Time.deltaTime;
            if (counterSkill >= 10f)
            {
                isCounter = true;
                counterSkill = 0f;
                isEndCounter = false;
            }
        }

        if (isCounter == true || isEndCounter == false)
        {
            counterTxt.gameObject.SetActive(true);
            counterSkillTime += Time.deltaTime;
            Debug.Log("countering" + counterSkillTime);
            if (counterSkillTime >= 3)
            {
                Debug.Log("Over Countering");
                counterTxt.gameObject.SetActive(false);
                isCounter = false;
                isEndCounter = true;
                counterSkillTime = 0;
                
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow") && isCounter == true)
        {
            enemyHp += 20f;
            target.gameObject.GetComponent<PlayerMovement>().health -= 10;
            counterTxt.gameObject.SetActive(false);
            counterSkill = 0f;
            isCounter = false;
            counterSkillTime = 0;
            isEndCounter = true;
        }
    }
}
