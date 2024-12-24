using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag){
            case "Friendly": Debug.Log("Everything is looking good!");; break;
            case "Fuel": Debug.Log("You're all done, welcome to our country"); break;
            case "Finish": LoadNextScene(); break;
            default: ReloadLevel(); break;
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
}
