using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    //Player player;
    // Start is called before the first frame update
    WeaponSpecs activeWeapon;
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim.GetBool("Walking"));
        //
        //activeWeapon = player.activeWeapon;
    }
    void Print(){
        Debug.Log(anim.GetBool("Walking"));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player.switchingGun){
            //activeWeapon = player.activeWeapon;
            bool rifle = player.activeWeapon.weaponName == "Assault Rifle";
            bool pistol = player.activeWeapon.weaponName == "Pistol";
            bool sniper = player.activeWeapon.weaponName == "Bolt Action";
            anim.SetBool("PistolEquipped", pistol);
            anim.SetBool("ArEquipped", rifle);
            anim.SetBool("SniperEquipped", sniper);
            StartCoroutine(player.animateWeapons(pistol, rifle, sniper));
        }
        
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            //Debug.Log("walkingggg");
            anim.SetBool("Walking", true);
        }else{
            anim.SetBool("Walking", false);
        }
    }
}
