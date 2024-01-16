using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectClass : MonoBehaviour
{
    public static ClassSpecs activeClass;

    private List<ClassSpecs> classes;

    // Use this for initialization
    void Start()
    {
        ClassSpecs rocket1 = new ClassSpecs("XBS-238", 100f, 10, 30f, 60, 1, 15f, 1.1f, 1000);
        ClassSpecs rocket2 = new ClassSpecs("FGZ-048", 300f, 10, 60f, 120, 2, 30f, 1.05f, 1500);
        ClassSpecs rocket3 = new ClassSpecs("PXM-879", 60f, 10, 12f, 80, 1, 20f, 1.3f, 750);

        this.classes = new List<ClassSpecs> { rocket1, rocket2, rocket3 };
        activeClass = rocket1;
    }

    public void setClass1()
    {
        activeClass = this.classes[0];
        LoadGame();
    }

    public void setClass2()
    {
        activeClass = this.classes[1];
        LoadGame();
    }

    public void setClass3()
    {
        activeClass = this.classes[2];
        LoadGame();
    }

    void LoadGame()
    {
        SceneManager.LoadSceneAsync("PlayerSandbox");
        SceneManager.UnloadSceneAsync("ClassSelectScreen");
    }
}
