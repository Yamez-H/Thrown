using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    public float Speed = 4f;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += Speed * Time.deltaTime * transform.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
