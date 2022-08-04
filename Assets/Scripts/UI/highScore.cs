using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScoreText.text = $"Highscore - {PlayerPrefs.GetInt("highScore")}";
        }
        else
        {
            highScoreText.text = "Highscore not set ... yet!";
        }
    }
}
