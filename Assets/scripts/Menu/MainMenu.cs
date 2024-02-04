using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool dbLoaded = false;
    [SerializeField]
    private AudioSource btnClick;
    void Start(){
        //Cursor.visible = true;
        if (!dbLoaded) {
            dbLoaded = true;
            //Load db here
            //PermanentStats.InitDb();
        }
    }

    public void StartGame(){
        btnClick.Play();
        StartCoroutine(NavigateToClassSelect());
    }
    IEnumerator NavigateToClassSelect(){
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync("ClassSelectScreen");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void QuitGame(){
        btnClick.Play();
        StartCoroutine(NavigateToQuitGame());
    }

    IEnumerator NavigateToQuitGame(){
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }

    public void ReturnToMenu(){
        btnClick.Play();
        StartCoroutine(NavigateToMenu());
    }

    IEnumerator NavigateToMenu(){
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainMenu");
    }

    public void NavigateToShop()
    {
        btnClick.Play();
        StartCoroutine(NavigateToUpgradeShop());
    }
    
    IEnumerator NavigateToUpgradeShop(){
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("UpgradeTab");
    }
}
