using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Damage = 5f;
    public float Speed = 4f;
    public float degrees;
    public float testX;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
    }

    private void FixedUpdate()
    {
        transform.position += Speed * Time.deltaTime * transform.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            GameObject enemy = collision.gameObject;
            enemy.SendMessage("ApplyDamage", Damage);
            //Debug.Log("enemy collision");
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Player") == true)
        {
            GameObject player = collision.gameObject;
            player.SendMessage("ApplyDamage", Damage);
            Destroy(gameObject);
            //Debug.Log("player collision");
        }
        else if (collision.gameObject.tag.Equals("Platform") == true)
        {

        }
        else
        {
            //Debug.Log("else destroy");
            Destroy(gameObject);
        }
        
    }

}
