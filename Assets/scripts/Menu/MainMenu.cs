using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool dbLoaded = false;
    void Start(){
        //Cursor.visible = true;
        if (!dbLoaded) {
            dbLoaded = true;
            //Load db here
            //PermanentStats.InitDb();
        }
    }
    public void StartGame(){
        SceneManager.LoadSceneAsync("ClassSelectScreen");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void NavigateToShop()
    {
        SceneManager.LoadScene("UpgradeTab");
    }
}
