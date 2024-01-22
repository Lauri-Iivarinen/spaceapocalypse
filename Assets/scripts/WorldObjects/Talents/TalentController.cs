using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentController : MonoBehaviour
{
    Player pl;
    
    //Beam
    public GameObject beam;
    public static bool beamPickedUp = false;
    public static float beamSpawnRate = 1f;
    //mine
    public GameObject mine;
    public static bool minePickedUp = false;
    public static float mineSpawnRate = 1f;

    void ResetPowerups(){
        beamPickedUp = false;
        beamSpawnRate = 1f;
        Beam.damage = 15f;
        BeamController.beamSize = 1f;
        BeamController.speed = 1f;

        minePickedUp = false;
        mineSpawnRate = 1f;
        Mine.damage = 150f;
        MineRadiusController.explosionRadius = 1f;
    }

    void Start(){
        pl = GameObject.Find("Player").GetComponent<Player>();
        ResetPowerups();
    }

    public void PickupMine(){
        StartCoroutine(SpawnMine());
        UiDisplay.PickedUpMine();
        minePickedUp = true;
    }
    public void PickUpBeam(){
        StartCoroutine(SpawnBeam());
        beamPickedUp = true;
        UiDisplay.PickedUpBeam();
    }

    IEnumerator SpawnBeam(){
        yield return new WaitForSeconds(5f/beamSpawnRate);
        Instantiate(beam, transform.position, transform.rotation);
        StartCoroutine(SpawnBeam());
    }

    IEnumerator SpawnMine(){
        yield return new WaitForSeconds(4f/mineSpawnRate);
        Instantiate(mine, transform.position, transform.rotation);
        StartCoroutine(SpawnMine());
    }
}