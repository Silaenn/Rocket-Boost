using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

     bool isControllable = true;
     bool isCollidable = true;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        RespondToDebugKeys();
    }

    private void OnCollisionEnter(Collision other) {
        if(!isControllable || !isCollidable) {
            return; 
        }

        switch(other.gameObject.tag){
            case "Friendly": Debug.Log("Everything is looking good!");; break;
            case "Fuel": Debug.Log("You're all done, welcome to our country"); break;
            case "Finish": StartSuccessSeqFinishuence(); break;
            default: StartCrashSequence();break;
        }
    }

    private void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay); 
    }

    void StartSuccessSeqFinishuence(){
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        successParticles.Play();
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

     void RespondToDebugKeys() {
        if (Keyboard.current.lKey.wasPressedThisFrame){
            LoadNextScene();
        } else if(Keyboard.current.cKey.wasPressedThisFrame) {
            isCollidable = !isCollidable;
        }
     }  
}
