using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //will use for uGUI to work 

public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI _UI_TEXT;

    static private int _SCORE = 1000;

    private TextMeshProUGUI txtCom; //txtCom is referenc eto this GO's text componnent
    // Start is called before the first frame update

    void Awake()
    {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();

        //if the playerPrefs has a highscorealready, reead it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }


        //Assign the high score to the HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);

            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }

        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return; //if scoreToTry is too low, return
        SCORE = scoreToTry;
    }

    //the following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            SCORE = 1000;
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }

    void Update()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.DeleteKey("HighScore"); // remove the key entirely
            SCORE = 1000;
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }



}