using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2DController : MonoBehaviour
{
    public float score = 0;
    public float Maxhealth = 20;
    private float health;

    public float MovmentSpeed;
    public float JumpForce;

    public float fireSpeed = 5.0f;
    private float fireCount = 0.0f;

    public ProjectileBehaviour projectilePrefab;
    public Transform LaunchOffset;

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private Rigidbody2D _rigidbody;
    //private bool canJump = false;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        health = Maxhealth;
        LoadProgress();

        var parent = GameObject.FindGameObjectWithTag("PlayerHUD").transform;

        var childOfParent = parent.GetChild(0);
        spriteRenderer = childOfParent.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }

    private void FixedUpdate()
    {
        var movment = Input.GetAxis("Horizontal");
        if(CrosshairSide(CrosshairAngle()) == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position += new Vector3(movment, 0, 0) * Time.deltaTime * MovmentSpeed;

        if (Input.GetButton("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        fireCount -= Time.deltaTime;
        if ((Input.GetButton("Fire1")) && (fireCount <= 0.0f))
        {

            LaunchProjectile(CrosshairAngle());
            fireCount = fireSpeed;
        }
    }

    private bool CrosshairSide(float degrees)
    {
        bool side = false; //fasle = right, true = left

        degrees = Mathf.Abs(degrees);
        if (degrees > 90)
            side = true;

        return side;
    }

    private float CrosshairAngle()
    {
        GameObject test = GameObject.Find("Crosshair");
        Vector2 pos = test.GetComponent<crosshairBehaviourScript>().crosshairPos;

        float distanceX = pos.x - transform.position.x;

        float distanceY = pos.y - transform.position.y;

        float degrees = Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg;
        return degrees;
    }

    private void LaunchProjectile(float degrees)
    {
        //Debug.Log("degrees = " + degrees);
        Instantiate(projectilePrefab, LaunchOffset.position, Quaternion.Euler(0, 0, degrees));
    }

    void ChangeSprite(int i)
    {
        spriteRenderer.sprite = spriteArray[i];
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        LoadProgress();
        score -= damage;
        SaveProgress();
        float temp = health / Maxhealth;
        temp = Mathf.RoundToInt(temp * 6);
        ChangeSprite((int)temp);
        if (health <= 0)
        {
            //Destroy(gameObject);
            score = 0;
            SaveProgress();
            SceneManager.LoadScene("Level1");
        }
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetFloat("Player Score", score);

        if (PlayerPrefs.GetFloat("Player High Score") < score)
        {
            PlayerPrefs.SetFloat("Player High Score", score);
        }
    }

    public void LoadProgress()
    {
        score = PlayerPrefs.GetFloat("Player Score");
    }
}
