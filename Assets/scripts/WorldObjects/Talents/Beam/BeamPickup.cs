using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPickup : MonoBehaviour, TalentPickup
{

    public static GameObject obj;
    public float GetX(){
        return obj.transform.position.x;
    }

    public float GetY(){
        return obj.transform.position.y;
    }

    public bool PickedUp(){
        return TalentController.beamPickedUp;
    }

    void Start(){
        obj = gameObject;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("Player")){
            TalentController talents = GameObject.Find("Player").GetComponent<TalentController>();
            talents.PickUpBeam();
            Destroy(gameObject);
        }
    }
}