using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("Player")){
            TalentController talents = GameObject.Find("Player").GetComponent<TalentController>();
            talents.PickupMine();
            Destroy(gameObject);
        }
    }
}