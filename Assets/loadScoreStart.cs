using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScoreStart : MonoBehaviour
{

    public float score;
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("Player High Score", 0);
        LoadProgress();
        scoreText = GameObject.FindGameObjectWithTag("Score");
        string scoreString = "High Score: " + score.ToString();
        scoreText.GetComponent<UnityEngine.UI.Text>().text = scoreString;
    }

    public void LoadProgress()
    {
        score = PlayerPrefs.GetFloat("Player High Score");
    }
}
