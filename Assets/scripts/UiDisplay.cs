using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UiDisplay : MonoBehaviour
{
    private TextMeshProUGUI gunDisplay;
    private TextMeshProUGUI levelDisplay;

    private TextMeshProUGUI hp;
    private TextMeshProUGUI dmg;
    private TextMeshProUGUI rawDmg;
    private TextMeshProUGUI atkSpeed;
    private TextMeshProUGUI speed;
    private TextMeshProUGUI crit;
    private TextMeshProUGUI critDmg;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider xpBar;

    private Player player;
    private string gunName = "empty";

    public void setWeaponName(string name){
        this.gunName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.xpBar = GameObject.Find("xp_bar").GetComponent<Slider>();
        this.healthBar = GameObject.Find("health_bar").GetComponent<Slider>();
        this.player = GameObject.Find("Player").GetComponent<Player>();
        this.gunDisplay = GameObject.Find("gun_display").GetComponent<TextMeshProUGUI>();
        this.levelDisplay = GameObject.Find("level_display").GetComponent<TextMeshProUGUI>();

        this.hp = GameObject.Find("HP").GetComponent<TextMeshProUGUI>();
        this.dmg = GameObject.Find("DMG").GetComponent<TextMeshProUGUI>();
        this.rawDmg = GameObject.Find("RawDMG").GetComponent<TextMeshProUGUI>();
        this.speed = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
        this.crit = GameObject.Find("Crit%").GetComponent<TextMeshProUGUI>();
        this.critDmg = GameObject.Find("CritDMG").GetComponent<TextMeshProUGUI>();
        this.atkSpeed = GameObject.Find("atkSpeed").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.xpBar.value = (float)player.stats.currXp / player.stats.xpRequired;
        this.healthBar.value = (float)player.stats.currHealth / player.stats.maxHealth;
        this.gunDisplay.text= this.gunName;
        this.levelDisplay.text = "" + player.stats.level;

        this.hp.text = "Max Health: " + player.stats.maxHealth;
        this.dmg.text = "Damage Increase: " + player.stats.damageMultiplier*100 + "%";
        this.speed.text = "Rocket Speed: " + player.stats.speed;
        this.crit.text = "Crit Chance: " + player.stats.critChance*100 + "%";
        this.critDmg.text = "Crit Dmg: " + player.stats.critDamageMultiplier * 100 + "%";
        this.atkSpeed.text = "Atk Speed: " + player.stats.attackSpeed *100 + "%";
        this.rawDmg.text = "Damage: " + (player.activeClass.weaponDamage * player.stats.damageMultiplier*10).ToString("0.00");
    }
}