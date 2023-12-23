using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobRangeFinder : MonoBehaviour
{
    public RangedMob mob;
    // Start is called before the first frame update
    void Start()
    {
        mob = transform.parent.gameObject.GetComponent<RangedMob>();
    }

    void OnTriggerEnter2D(Collider2D objectName)
    {
        if (objectName != null && objectName.gameObject.name.Contains("Player"))
        {
            //Start shooting
            mob.inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D objectName)
    {
        if (objectName != null && objectName.gameObject.name.Contains("Player"))
        {
            //Stop shooting and start closing in on the player
            mob.inRange = false;
        }
    }
}
