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
    public WeaponSpecs activeWeapon;
    private List<WeaponSpecs> weapons;
    public bool switchingGun = false;
    private const int SWITCHDELAY = 120;
    private int currDelay = 0;
    private const int DAMAGETICK = 45;
    private int damageInterval = 0; //Restricts taking damage in every tick
    public GameObject pistolObj;
    public GameObject rifleObj;
     public GameObject sniperObj;
    
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
        //Debug.Log(obj.gameObject.name);
        if(!obj.gameObject.name.Contains("Bullet")){
            if (this.damageInterval <= 0){
                this.stats.currHealth -= 15;
                this.damageInterval = DAMAGETICK;
            }
        }

    }

    void OnTriggerStay2D(Collider2D obj){
        if(!obj.gameObject.name.Contains("Bullet")){
            if (this.damageInterval <= 0){
                this.stats.currHealth -= 15;
                this.damageInterval = DAMAGETICK;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pistolObj = GameObject.Find("pistol");
        rifleObj = GameObject.Find("assaultRifle");
        rifleObj.SetActive(false);
        sniperObj = GameObject.Find("sniper");
        sniperObj.SetActive(false);
        stats = new PlayerStats();
        movementSpeed = 0.1f * stats.speed;
        WeaponSpecs pistol = new WeaponSpecs("Pistol", 1f, 10, 30, 60, 1, 15f);
        WeaponSpecs sniper = new WeaponSpecs("Bolt Action", 3, 5, 120, 100, 3, 30f);
        WeaponSpecs smg = new WeaponSpecs("Assault Rifle", 0.7f, 25, 15, 75, 1, 20f);

        this.weapons = new List<WeaponSpecs>{pistol,sniper, smg};
        this.activeWeapon = pistol;
        this.display = GameObject.Find("Canvas").GetComponent<UiDisplay>();
        display.setWeaponName(this.activeWeapon.weaponName);
        Debug.Log("Logging started");
    }

    void playerDies(){
        SceneManager.LoadScene("DeathScreen");
    }

    public IEnumerator animateWeapons(bool pistol, bool rifle, bool sniper){
        yield return new WaitForSeconds(1f);
        pistolObj.SetActive(pistol);
        rifleObj.SetActive(rifle);
        sniperObj.SetActive(sniper);
    }

    public void DelayAnimation(){

    }

    // Update is called once per frame
    void FixedUpdate(){
        transform.Rotate(0,0,0);
        if (!this.switchingGun){
            if (Input.GetKey("1")){
                this.switchingGun = true;
                this.currDelay = SWITCHDELAY;
                this.activeWeapon = this.weapons[0];
                display.setWeaponName(this.activeWeapon.weaponName);
                
            }else if (Input.GetKey("2")){
                this.switchingGun = true;
                this.currDelay = SWITCHDELAY;
                this.activeWeapon = this.weapons[1];
                display.setWeaponName(this.activeWeapon.weaponName);
            }else if (Input.GetKey("3")){
                this.switchingGun = true;
                this.currDelay = SWITCHDELAY;
                this.activeWeapon = this.weapons[2];
                display.setWeaponName(this.activeWeapon.weaponName);
            }

        }else{
            if (currDelay > 0){
                this.currDelay--;
            }else{
                this.switchingGun = false;
            }
        }

        if (stats.currHealth > 0 && !switchingGun){//Dead dont walk (unles they are zombies :3)
            this.x = Input.GetAxis("Horizontal");
            this.y = Input.GetAxis("Vertical");
            transform.Translate(this.x * movementSpeed, this.y * movementSpeed, 0);
        }else if(stats.currHealth <= 0){
            playerDies();
        }
        if (damageInterval > 0){
            damageInterval--;
        }
        
    }
}
