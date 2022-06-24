using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviourScript : MonoBehaviour
{
    public float Maxhealth = 10;
    public float health;

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
        var button = gameObject.transform;

        var childOfButton = button.GetChild(0);

        spriteRenderer = childOfButton.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeSprite(int i)
    {
        spriteRenderer.sprite = spriteArray[i];
    }

    public void ApplyDamage(float damage)
    {
        health = health - damage;
        float temp = health / Maxhealth;
        temp = Mathf.RoundToInt(temp * 6);
        ChangeSprite((int)temp);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
