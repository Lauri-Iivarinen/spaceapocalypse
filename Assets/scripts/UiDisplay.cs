using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiDisplay : MonoBehaviour
{
    private TextMeshProUGUI hptxt;
    private TextMeshProUGUI xptxt;
    private int hp;
    private int xp;

    public void setHealth(int num){
        this.hp = num;
    }

    public void setXp(int amount){
        this.xp = amount;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.hp = 200;
        this.hptxt = GameObject.Find("health_display").GetComponent<TextMeshProUGUI>();
        this.xptxt = GameObject.Find("xp_display").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.hptxt.text = "HP: " + this.hp;
        this.xptxt.text = "XP: " + this.xp;
    }
}