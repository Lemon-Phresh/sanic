using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishGame : MonoBehaviour
{
    public Text bigScore;
    public GameObject highScoreGM, bigScoreGM;

    public float t_;
    public bool t;

    // Start is called before the first frame update
    void Start()
    {
        t = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(t)
        {
            t_ = t_ - Time.deltaTime;
        }
        
        if (t_ <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void FinishGame()
    {
        if(eggmanMove.score > highscoreManager.highscore)
        {
            eggmanMove.score = highscoreManager.highscore;
            PlayerPrefs.SetInt ("highscore", highscoreManager.highscore);
            highScoreGM.SetActive(true);
        }
        bigScoreGM.SetActive(true);
        t_ = 5f;
        t = true;
    }
}
