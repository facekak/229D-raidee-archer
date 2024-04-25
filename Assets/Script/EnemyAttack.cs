using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bullet;

    public float reloadingArrow;
    public float reloadArrowTime = 0.5f;

    /*public Slider reloadBar;

    public TextMeshProUGUI reloadingText;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadingArrow += Time.deltaTime;

        if (reloadingArrow >= reloadArrowTime)
        {
            target.transform.position = new Vector2(target.transform.position.x, target.transform.position.y);
            Debug.Log(" Player Hit point : " + target.transform.position);
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
    
}
