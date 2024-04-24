using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDespawn : MonoBehaviour
{
    public float despawnCountdonw;

    public float arrowDespawnTime;
    
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
}
