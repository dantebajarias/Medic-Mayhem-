using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isMute;
    public AudioSource as_;

    void Start(){
        as_ = GetComponent<AudioSource>();
    }
    
    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Reset(){
        PlayerPrefs.DeleteKey("highscore");
    }

    public void Mute(){
        isMute = ! isMute;
        as_e.volume = isMute? 0:0.093;
    }
}
