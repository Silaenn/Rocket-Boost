using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag){
            case "Friendly": Debug.Log("Everything is looking good!");; break;
            case "Fuel": Debug.Log("You're all done, welcome to our country"); break;
            case "Finish": StartSuccessSeqFinishuence(); break;
            default: StartCrashSequence();break;
        }
    }

    private void StartCrashSequence()
    {
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay); 
    }

    void StartSuccessSeqFinishuence(){
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", delay);
    }



    void ReloadLevel(){
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
        void LoadNextScene(){
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;

            if(nextScene == SceneManager.sceneCountInBuildSettings){
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
        }
}
