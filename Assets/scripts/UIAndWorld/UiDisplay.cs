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
    private TextMeshProUGUI hps;
    private TextMeshProUGUI penetration;
    private TextMeshProUGUI killCount;

    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider boostBar;
    [SerializeField] private Slider xpBar;

    public static GameObject beamPowerup;

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
        this.boostBar = GameObject.Find("boost_bar").GetComponent<Slider>();
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
        this.hps = GameObject.Find("HPS").GetComponent<TextMeshProUGUI>();
        this.penetration = GameObject.Find("Penetration").GetComponent<TextMeshProUGUI>();


        this.killCount = GameObject.Find("Counter").GetComponent<TextMeshProUGUI>();
        beamPowerup = GameObject.Find("BeamPowerup");
        beamPowerup.SetActive(false);
    }

    public static void PickedUpBeam(){
        beamPowerup.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.xpBar.value = (float)player.stats.currXp / player.stats.xpRequired;
        this.healthBar.value = (float)player.stats.currHealth / player.stats.maxHealth;
        this.boostBar.value = player.stats.currBoost / player.stats.BOOSTCAP;
        this.gunDisplay.text= this.gunName;
        this.levelDisplay.text = "" + player.stats.level;

        this.hp.text = "Max Health: " + player.stats.maxHealth;
        this.dmg.text = "Damage Multiplier: " + (player.stats.damageMultiplier*100).ToString("0.0") + "%";
        this.speed.text = "Rocket Speed: " + player.stats.speed.ToString("0.0");
        this.crit.text = "Crit Chance: " + player.stats.critChance*100 + "%";
        this.critDmg.text = "Crit Dmg: " + (player.stats.critDamageMultiplier * 100).ToString("0.0") + "%";
        this.atkSpeed.text = "Atk Speed: " + (player.stats.attackSpeed *100).ToString("0.0") + "%";
        this.rawDmg.text = "Damage: " + (player.activeClass.weaponDamage * player.stats.damageMultiplier).ToString("0.0");
        this.hps.text = "HPS: " + player.stats.healthRegen/4;
        this.penetration.text = "Penetration: " + (player.stats.bulletPenetration + player.activeClass.penetration).ToString("0.0");
        this.killCount.text = "" + PlayerStats.killCount;
    }
}