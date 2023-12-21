using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    Player player;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.stats.currHealth <= 0) {
            anim.SetBool("Alive", false);
        } else if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            //Debug.Log("walkingggg");
            anim.SetBool("Walking", true);
        } else{
            anim.SetBool("Walking", false);
        }
    }
}
