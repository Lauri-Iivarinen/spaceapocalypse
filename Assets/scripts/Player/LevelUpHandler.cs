using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpHandler : MonoBehaviour
{
    public GameObject obj;
    public static bool paused;
    public PauseMenu pause;

    // Start is called before the first frame update
    public string[] upgrades;
    //public Player pl;
    void Start()
    {
        pause = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        obj.SetActive(false);
    }

    //Pause game, randomize some upgrades to choose from
    public void InitiateLevelUp(string[] options){
        upgrades = options;
        pause.allowPause = false;
        StartCoroutine(LevelUp());
    }

    IEnumerator LevelUp(){
        yield return new WaitForSeconds(0.5f);
        obj.SetActive(true);
        GameObject.Find("Select1").GetComponentInChildren<TextMeshProUGUI>().text = upgrades[0];
        GameObject.Find("Select2").GetComponentInChildren<TextMeshProUGUI>().text = upgrades[1];
        GameObject.Find("Select3").GetComponentInChildren<TextMeshProUGUI>().text = upgrades[2];
        paused = true;
        Time.timeScale = 0f;
    }

    public void SelectOption1(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        pl.stats.IncreaseStat(upgrades[0]);
        ResumeGame();
    }
    public void SelectOption2(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        pl.stats.IncreaseStat(upgrades[1]);
        ResumeGame();
    }
    public void SelectOption3(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        pl.stats.IncreaseStat(upgrades[2]);
        ResumeGame();
    }

    public void ResumeGame(){
        paused = false;
        obj.SetActive(false);
        Time.timeScale = 1f;
        pause.allowPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
