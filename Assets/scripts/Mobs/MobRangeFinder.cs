using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobRangeFinder : MonoBehaviour
{
    //public MobActions mob;
    // Start is called before the first frame update
    void Start()
    {
        MobActions mob = transform.parent.gameObject.GetComponent<MobActions>();
    }

    void OnTriggerEnter2D(Collider2D objectName)
    {
        if (objectName != null && objectName.gameObject.name.Contains("Player"))
        {
            MobActions mob = transform.parent.gameObject.GetComponent<MobActions>();
            //Start shooting
            mob.SetInRange(true);
        }
    }

    void OnTriggerExit2D(Collider2D objectName)
    {
        if (objectName != null && objectName.gameObject.name.Contains("Player"))
        {
            MobActions mob = transform.parent.gameObject.GetComponent<MobActions>();
            //Stop shooting and start closing in on the player
            mob.SetInRange(false);
        }
    }
}
