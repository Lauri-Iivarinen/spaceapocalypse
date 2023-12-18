using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mob : MonoBehaviour
{

    private int health = 10;
    public Player player;

    void OnTriggerEnter2D(Collider2D objectName)
    {
        Debug.Log(objectName.gameObject.name + " " + health);
        {
            
        }
        if(!objectName.gameObject.name.Equals("Player")){
            this.health--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HEHEE ZOMBIE HERE");
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Die(){
        Destroy(gameObject);
        this.player.gainXp(26);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            this.Die();
        }
    }
}
