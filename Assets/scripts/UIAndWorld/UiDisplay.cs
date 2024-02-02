using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.AI;

public class UiDisplay : MonoBehaviour
{
    [SerializeField] public TMP_FontAsset FontAsset;
    private TextMeshProUGUI gunDisplay;
    private TextMeshProUGUI levelDisplay;

    private TextMeshProUGUI timer;
    public static bool timeRunning = true;
    private float timeRemaining = 0;

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

    [SerializeField] private Slider bossHealthBar;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider boostBar;
    [SerializeField] private Slider xpBar;

    public GameObject _beamPowerup;
    public GameObject _minePowerup;
    public GameObject _multiShotPowerUp;

    public static GameObject beamPowerup;
    public static GameObject minePowerup;
    public static GameObject multiShotPowerUp;

    private Player player;
    private string gunName = "empty";
    private static float iconX = 0;

    public MobBaseline boss;
    GameObject bossData;
    private TextMeshProUGUI bossName;

    private bool gameEnding = false;
    GameObject gameEndScreen;
    GameObject gameEndingScreenText;
    float fill = 0f;
    public void setWeaponName(string name){
        this.gunName = name;
    }

    public void SpawnBoss(MobBaseline bossStats){
        bossData.SetActive(true);
        boss = bossStats;
        bossName.text = bossStats.mobName;
    }

    IEnumerator EndGameText(){
        yield return new WaitForSeconds(4.5f);
        Time.timeScale = 0f;
        gameEndingScreenText.SetActive(true);
        GameObject.Find("EndGameKillCount").GetComponent<TextMeshProUGUI>().text = "" + PlayerStats.killCount;
    }

    IEnumerator EndGame(){
        yield return new WaitForSeconds(2);
        gameEnding = true;
        gameEndScreen.SetActive(true);
        StartCoroutine(EndGameText());
    }

    public void BossDied(){
        bossData.SetActive(false);
        StartCoroutine(EndGame());
    }

    // Start is called before the first frame update
    void Start()
    {   
        timeRunning = true;
        this.bossName = GameObject.Find("boss_name").GetComponent<TextMeshProUGUI>();
        this.bossHealthBar = GameObject.Find("boss_health_bar").GetComponent<Slider>();
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
        bossData = GameObject.Find("boss_data");
        bossData.SetActive(false);
        beamPowerup = _beamPowerup;
        minePowerup = _minePowerup;
        multiShotPowerUp = _multiShotPowerUp;

        this.timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        gameEndScreen = GameObject.Find("GameCompleted");
        gameEndingScreenText = GameObject.Find("GameCompletedView");
        gameEndingScreenText.SetActive(false);
        gameEndScreen.SetActive(false);
    }

    public static void PickedUpBeam(){
        //beamPowerup.SetActive(true);
        if (!TalentController.beamPickedUp){
            Vector3 pos = new Vector3(1490+iconX, -888f, 0f);
            GameObject obj = Instantiate(beamPowerup, pos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Play").transform, false);
            iconX -= 110;
        }
    }

    public static void PickedUpMine(){
        if (!TalentController.minePickedUp){
            Vector3 pos = new Vector3(1490+iconX, -888f, 0f);
            GameObject obj = Instantiate(minePowerup, pos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Play").transform, false);
            iconX -= 110;
        }
    }

    public static void PickedUpMultiShot(){
        if(!TalentController.multiShotPickedUp){
            Vector3 pos = new Vector3(1490+iconX, -888f, 0f);
            GameObject obj = Instantiate(multiShotPowerUp, pos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Play").transform, false);
            iconX -= 110;
        }
    }

    void displayTime(float time){
        time+=1;
        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);

        if (minutes < 0){
            timer.text = "0:00";
        }else{
            timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameEnding){
            Image img = gameEndScreen.GetComponentInChildren<Image>();
            img.color = new Color(0f,0f,0f,fill);
            fill += 0.005f;
        }

        timeRemaining += Time.deltaTime;
        displayTime(8*60 - timeRemaining);

        if (boss != null){
            this.bossHealthBar.value = boss.health / boss.maxHealth;
        }
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