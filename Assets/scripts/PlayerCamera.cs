using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float movementSpeed;
    public float x;
    public float y;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (player.getHealth() > 0){
            this.x = Input.GetAxis("Horizontal");
            this.y = Input.GetAxis("Vertical");
            transform.Translate(this.x * movementSpeed, this.y * movementSpeed, 0);
        }
    }
}
