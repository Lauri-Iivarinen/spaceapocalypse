using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
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
    
    public float GetX(){
        return transform.position.x;
    }

    public float GetY(){
        return transform.position.y;
    }

    public int getHealth(){
        return stats.currHealth;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("Mob")){
            if (this.damageInterval <= 0){
                this.stats.currHealth -= 15;
                this.damageInterval = DAMAGETICK;
            }
        }
    }

    void OnTriggerStay2D(Collider2D obj){
        if(obj.gameObject.name.Contains("Mob")){
            if (this.damageInterval <= 0){
                this.stats.currHealth -= 15;
                this.damageInterval = DAMAGETICK;
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
        if (stats.currHealth > 0 && !switchingGun){//Dead dont walk (unles they are zombies :3)
            this.x = Input.GetAxis("Horizontal");
            this.y = Input.GetAxis("Vertical");
            transform.Translate(this.x * movementSpeed, this.y * movementSpeed, 0);
        }else if(stats.currHealth <= 0){
            playerDies();
        }
        if (damageInterval > 0){//Prevents player from taking damage every tick
            damageInterval--;
        }
        
    }
}
