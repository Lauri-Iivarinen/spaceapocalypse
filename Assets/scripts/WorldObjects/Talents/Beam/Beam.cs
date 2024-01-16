using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private float damage = 15f;
    private bool crit = false;

    void OnTriggerEnter2D(Collider2D objectName)
    {
        if (objectName.gameObject.name.Contains("Mob") && !objectName.gameObject.name.Contains("MobBullet"))
        {
            MobActions mob = objectName.gameObject.GetComponent<MobActions>();
            mob.TakeDamage(this.damage, this.crit);
            
        }
    }
}
