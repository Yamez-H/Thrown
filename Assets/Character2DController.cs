using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovmentSpeed;
    public float JumpForce;
    public float fireSpeed = 20;

    public ProjectileBehaviour projectilePrefab;
    public Transform LaunchOffset;

    private Rigidbody2D _rigidbody;
    private bool canJump = false;
    public float fireCount = 20;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        var movment = Input.GetAxis("Horizontal");
        if(movment < 0)
        {
            //transform.localEulerAngles = transform.eulerAngles + new Vector3(0, 180, -2 * transform.eulerAngles.z);
        }
        transform.position += new Vector3(movment, 0, 0) * Time.deltaTime * MovmentSpeed;

        if (Input.GetButton("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if ((Input.GetButton("Fire1")) && (fireCount >= fireSpeed))
        {
            Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
            fireCount = 0;
        }
        fireCount++;
    }

    private void LaunchProjectile()
    {
        Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
    }
}
