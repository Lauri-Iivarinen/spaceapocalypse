using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject obj;
    public static bool paused;
    public bool allowPause = true;
    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) && allowPause){
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
        //UiDisplay.timeRunning = true;
        //Cursor.visible = false;
    }

    public void PauseGame(){
        //UiDisplay.timeRunning = false;
        obj.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
        //Cursor.visible = true;
    }

    public void ReturnToMenu(){
        paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("playerSandbox");
    }
}
