using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public static float score;
    public static float highscore;

    void Start(){

        highscore = PlayerPrefs.GetFloat("highscore", 0);
        highscoreText.text = "High Score: " + ((int)highscore).ToString();
        
    }
    
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player")!= null){
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }else{
            score = 0;
        }
        if(highscore < score){

            PlayerPrefs.SetFloat("highscore", score);
            highscoreText.text = "High Score: " + ((int)score).ToString();
        }
    }
}
