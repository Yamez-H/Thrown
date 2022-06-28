using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoorBehaviourScript1 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        var parent = gameObject.transform;
        //var childOfParent = parent.GetChild(0);
        spriteRenderer = parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == false)
        {
            win = true;
            spriteRenderer.sprite = spriteArray[1];
            Debug.Log("PLAYER WINS GAME");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") == true && win == true)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    void ChangeSprite(int i)
    {
        spriteRenderer.sprite = spriteArray[i];
    }
}
