using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public int health = 100;
    public float movementSpeed;
    public float x;
    public float y;

    public int xp;

    public UiDisplay display;

    public int getHealth(){
        return health;
    }

    public void gainXp(int amount){
        this.xp += amount;
        display.setXp(this.xp);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(!obj.gameObject.name.Contains("Bullet")){
            this.health-= 15;
            display.setHealth(this.health);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.xp = 0;
        this.display = GameObject.Find("Canvas").GetComponent<UiDisplay>();
        display.setHealth(this.health);
        Debug.Log("Logging started");
    }

    // Update is called once per frame
    void FixedUpdate(){
        this.x = Input.GetAxis("Horizontal");
        this.y = Input.GetAxis("Vertical");

        transform.Translate(this.x * movementSpeed, this.y * movementSpeed, 0);
    }
}
