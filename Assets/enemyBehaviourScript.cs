using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviourScript : MonoBehaviour
{
    public float health = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
