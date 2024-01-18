using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCapsule : MonoBehaviour
{
    private const float HEALING = 100f;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("Player")){
            Player pl = GameObject.Find("Player").GetComponent<Player>();
            pl.stats.HealthPickup(HEALING);
            Destroy(gameObject);
        }
    }
}
