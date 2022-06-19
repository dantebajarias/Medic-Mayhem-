using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public AudioSource as_;

    void Start(){
        as_ = GetComponent<AudioSource>();
    }
    
    private void Awake(){

        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }
    
    void Update(){

        if(SceneManager.GetActiveScene().name == "Game"){
            if(GameObject.FindGameObjectWithTag("Player") == null){

                as_.Stop();
            }
        } 
    }
}
