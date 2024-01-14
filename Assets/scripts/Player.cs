using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject dmgTxt;
    [SerializeField]
    private GameObject lvlUpPrefab;
    public float movementSpeed;
    public float x;
    public float y;
    public PlayerStats stats;
    public Gun gun;
    public UiDisplay display;
    public ClassSpecs activeClass;
    private List<ClassSpecs> classes;
    public bool switchingGun = false;
    private const int SWITCHDELAY = 120;
    private const int DAMAGETICK = 45;
    private int damageInterval = 0; //Restricts taking damage in every tick
    private const int HPREGENDELAY = 200;
    private int hpRegen = 0;

    public void LevelUpAnim(){
        StartCoroutine(ToggleSkillSelection());
        Instantiate(lvlUpPrefab, transform.position, Quaternion.identity, transform);
    }

    public float GetX(){
        return transform.position.x;
    }

    public float GetY(){
        return transform.position.y;
    }

    public float getHealth(){
        return stats.currHealth;
    }

    public IEnumerator ToggleSkillSelection(){
        yield return new WaitForSeconds(0.5f);
        LevelUpHandler lvlUp = GameObject.Find("Canvas").GetComponent<LevelUpHandler>();
        //Prob convert to tuples to display proper names in UI
        string[] upgradesAll = {"Damage Increase +5%", "Rocket Speed +5%", "Attack Speed +5%", "Maximum Health +150", "Critical Chance +7%", "Critical Damage +10%", "HPS +1", "Bullet penetration +10%"};
        string[] upgrades = {upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)], upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)], upgradesAll[UnityEngine.Random.Range(0, upgradesAll.Length)]};
        //Select 1 of 3, increase stat
        lvlUp.InitiateLevelUp(upgrades);
    }

    public void DisplayDamage(float dmg, Color color){
        Quaternion rot = transform.rotation;
        rot.z = 0;
        var txt = Instantiate(dmgTxt, transform.position, rot);
        txt.GetComponent<TextMesh>().text = "" + dmg;
        txt.GetComponent<TextMesh>().color = color;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("Mob")){
            if (this.damageInterval <= 0){
                this.stats.currHealth -= 150;
                this.damageInterval = DAMAGETICK;
                DisplayDamage(150f, new Color(100,0,0, 1f));
            }
        }
    }

    void OnTriggerStay2D(Collider2D obj){
        if(obj.gameObject.name.Contains("Mob")){
            if (this.damageInterval <= 0){
                this.stats.currHealth -= 150;
                this.damageInterval = DAMAGETICK;
                DisplayDamage(150f, new Color(100,0,0, 1f));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.activeClass = new ClassSpecs("XBS-238", 1f, 10, 30f, 60, 1, 15f, 1f, 100);
        this.activeClass = SelectClass.activeClass;
        stats = new PlayerStats();
        stats.maxHealth = activeClass.rocketHealth;
        stats.currHealth = activeClass.rocketHealth;
        stats.speed = activeClass.rocketSpeed;
        movementSpeed = 0.1f * stats.speed;
        //WeaponSpecs rocket1 = new WeaponSpecs("XBS-238", 1f, 10, 30, 60, 1, 15f);

        //this.weapons = new List<WeaponSpecs>{rocket1};
        
        this.display = GameObject.Find("Canvas").GetComponent<UiDisplay>();
        display.setWeaponName(this.activeClass.className);
        Debug.Log("Logging started");
    }


    IEnumerator DestroySprite(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DeathScreen");
    }

    void playerDies(){
        StartCoroutine(DestroySprite());
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (this.hpRegen <= 0){
            stats.GainHealth();
            this.hpRegen = HPREGENDELAY;
        }else{
            this.hpRegen--;
        }
        
        if (stats.currHealth > 0 && !switchingGun){//Dead dont walk (unles they are zombies :3)
            this.x = Input.GetAxis("Horizontal");
            this.y = Input.GetAxis("Vertical");
            float moveX = 0f;
            float moveY = 0f;
            if (Input.GetKey(KeyCode.W)) moveY += 1f;
            if (Input.GetKey(KeyCode.S)) moveY -= 1f;
            if (Input.GetKey(KeyCode.D)) moveX += 1f;
            if (Input.GetKey(KeyCode.A)) moveX -= 1f;


            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            //transform.Translate(this.x * movementSpeed, this.y * movementSpeed, 0);
            transform.position += moveDir * movementSpeed;
        }else if(stats.currHealth <= 0){
            playerDies();
        }
        if (damageInterval > 0){//Prevents player from taking damage every tick
            damageInterval--;
        }
        
    }
}
