using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject obj;
    public static bool paused;
    public bool allowPause = true;
    [SerializeField]
    private AudioSource btnClick;
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
        btnClick.Play();
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
        btnClick.Play();
        Time.timeScale = 1f;
        StartCoroutine(NavigateToMenu());
    }
    IEnumerator NavigateToMenu(){
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainMenu");
        SceneManager.UnloadSceneAsync("Level1");
    }
}
