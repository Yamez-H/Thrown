using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviourScript : MonoBehaviour
{
    public float Maxhealth = 10;
    private float health;

    public float speed = 10.0f;
    public float targetDistance = 5.0f;
    
    public float fireSpeed = 5.0f;
    private float fireCount = 0.0f;

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private GameObject Enemy;
    private GameObject Player;

    public ProjectileBehaviour projectilePrefab;
    public Transform LaunchOffset1;

    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
        fireCount = Random.Range(0.0f, 2.0f);

        var parent = gameObject.transform;
        var childOfParent = parent.GetChild(0);
        spriteRenderer = childOfParent.GetComponent<SpriteRenderer>();

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = Player.gameObject.transform.position;
        //pos = pos.normalized;
        //float distance = findPlayerDistance(pos);

        if (Mathf.Abs(FindPlayerAngle(pos)) > 90)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        float temp = FindPlayerDistance(pos);
        fireCount -= Time.deltaTime;
        if ((temp < targetDistance) && (fireCount <= 0.0f))
        {
            float degrees = FindPlayerAngle(pos);
            LaunchProjectile(degrees);
            fireCount = fireSpeed;
        }
        //Debug.Log("fireCount = " + fireCount);
    }

    float FindPlayerDistance(Vector2 pos)
    {
        //Vector2 pos = Player.GetComponent<crosshairBehaviourScript>().crosshairPos;

        float distanceX = pos.x - transform.position.x;

        float distanceY = pos.y - transform.position.y;

        float distance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);

        //Debug.Log("player distance = " + distance);

        return distance;
    }

    float FindPlayerAngle(Vector2 pos)
    {
        //Vector2 pos = Player.GetComponent<crosshairBehaviourScript>().crosshairPos;

        float distanceX = pos.x - transform.position.x;

        float distanceY = pos.y - transform.position.y;

        float degrees = Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg;
        return degrees;
        //transform.eulerAngles = Vector3.forward * degrees;

        //Debug.Log("degrees = " + degrees + "distanceX = " + distanceX + "distanceY" + distanceY);
    }

    private void LaunchProjectile(float degrees)
    {
        //transform.eulerAngles = Vector3.forward * degrees;

        //Debug.Log("enemy degrees = " + degrees);

        Instantiate(projectilePrefab, LaunchOffset1.position, Quaternion.Euler(0, 0, degrees));
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
