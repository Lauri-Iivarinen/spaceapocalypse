using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDisplay : MonoBehaviour
{
    private TextMeshProUGUI hptxt;
    private TextMeshProUGUI xptxt;
    private TextMeshProUGUI deathMsg;
    private TextMeshProUGUI gunDisplay;
    private TextMeshProUGUI levelDisplay;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider xpBar;

    private int hp;
    private int xp;
    private Player player;
    private string gunName = "empty";

    public void setHealth(int num){
        if (num <= 0){
            this.hp = 0;
            this.deathMsg.text = "YOU ARE DEAD";
        }else{
            this.hp = num;
        }
        
    }

    public void setWeaponName(string name){
        this.gunName = name;
    }

    public void setXp(int amount){
        this.xp = amount;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.xpBar = GameObject.Find("xp_bar").GetComponent<Slider>();
        this.healthBar = GameObject.Find("health_bar").GetComponent<Slider>();
        this.player = GameObject.Find("Player").GetComponent<Player>();
        this.deathMsg = GameObject.Find("death_display").GetComponent<TextMeshProUGUI>();
        this.gunDisplay = GameObject.Find("gun_display").GetComponent<TextMeshProUGUI>();
        this.levelDisplay = GameObject.Find("level_display").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.xpBar.value = (float)player.stats.currXp / player.stats.xpRequired;
        this.healthBar.value = (float)player.stats.currHealth / player.stats.maxHealth;
        this.gunDisplay.text="Weapon: " + this.gunName;
        this.levelDisplay.text = "" + player.stats.level;
    }
}