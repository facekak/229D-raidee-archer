using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHp = 100f;
    public TextMeshProUGUI enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth.text = $"<color=black>Enemy Health</color> <color=#E41B17>{enemyHp}</color>";
    }
    
   
}
