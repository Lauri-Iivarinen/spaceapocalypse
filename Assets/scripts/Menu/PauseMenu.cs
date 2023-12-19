using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject obj;
    public static bool paused;
    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("PauseMenu");
        obj.SetActive(false);
        paused = false;
 
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Pausing?");
            if (paused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }
    public void ResumeGame(){
        paused = false;
        Time.timeScale = 1f;
        obj.SetActive(false);
    }

    public void PauseGame(){
        paused = true;
        Time.timeScale = 0f;
        obj.SetActive(true);
    }

    public void ReturnToMenu(){
        paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("playerSandbox");
    }
}
