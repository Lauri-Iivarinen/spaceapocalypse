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
        ClassSpecs rocket1 = new ClassSpecs("XBS-238", 1f, 10, 30f, 60, 1, 15f, 1f, 100);
        ClassSpecs rocket2 = new ClassSpecs("FGZ-048", 3f, 10, 60f, 120, 3, 30f, 0.8f, 150);
        ClassSpecs rocket3 = new ClassSpecs("PXM-879", 0.6f, 10, 12f, 80, 1, 20f, 1.5f, 75);

        this.classes = new List<ClassSpecs> { rocket1, rocket2, rocket3 };
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
