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
        obj.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (paused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }
    public void ResumeGame(){
        paused = false;
        obj.SetActive(false);
        Time.timeScale = 1f;

    }

    public void PauseGame(){
        obj.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void ReturnToMenu(){
        paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("playerSandbox");
    }
}
