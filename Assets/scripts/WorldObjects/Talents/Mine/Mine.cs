using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public static float damage = 150f;
    public static bool crit = false;
    Animator anim;
    MineRadiusController ctrl;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ctrl = gameObject.GetComponentInParent<MineRadiusController>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(ctrl.active && obj.gameObject.name.Contains("Mob") && !obj.gameObject.name.Contains("Bullet")){
            anim.SetBool("Destroyed", true);
            ctrl.Explode();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
}
