using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    public float Speed = 4f;
    public float degrees;
    public float testX;

    private void Update()
    {
        GameObject test = GameObject.Find("Crosshair");
        Vector2 pos = test.GetComponent <crosshairBehaviourScript>().crosshairPos;

        float distanceX = pos.x - transform.position.x;

        testX = distanceX;

        float distanceY = pos.y - transform.position.y;
        float hyp = Mathf.Sqrt(((distanceX * distanceX) + (distanceY * distanceY)));

        float angle = Mathf.Cos(distanceX / hyp);
        degrees = angle * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.forward * degrees;
    }

    private void FixedUpdate()
    {
        transform.position += Speed * Time.deltaTime * transform.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            gameObject.SendMessage("ApplyDamage", 10.0);
        }

        Destroy(gameObject);
    }

}
