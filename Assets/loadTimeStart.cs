using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadTimeStart : MonoBehaviour
{

    public float time = 1;
    private GameObject timeText;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("Player Lowest Time", 999);
        LoadProgress();
        timeText = GameObject.FindGameObjectWithTag("Time");
        string scoreString = "Best Time: " + time.ToString("F2");
        timeText.GetComponent<UnityEngine.UI.Text>().text = scoreString;
    }

    public void LoadProgress()
    {
        time = PlayerPrefs.GetFloat("Player Lowest Time");
    }
}
