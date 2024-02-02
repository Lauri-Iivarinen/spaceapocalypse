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
    //Multishot
    public GameObject bullet;
    public static bool multiShotPickedUp = false;
    public static float multiShotFireRate = 1f;
    public static float bulletDamage = 85f;
    public static int multiShotCount = 3;

    [SerializeField]
    private AudioSource mineSpawnAudio;

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

        multiShotPickedUp = false;
        multiShotFireRate = 1f;
        multiShotCount = 3;
        bulletDamage = 85;
    }

    void Start(){
        pl = GameObject.Find("Player").GetComponent<Player>();
        ResetPowerups();
    }

    public void PickupMine(){
        if(!minePickedUp){
            StartCoroutine(SpawnMine());
            UiDisplay.PickedUpMine();
        }
        minePickedUp = true;
    }
    public void PickUpBeam(){
        if(!beamPickedUp){
            StartCoroutine(SpawnBeam());
            UiDisplay.PickedUpBeam();
        }
        beamPickedUp = true;
    }
    public void PickUpMultiShot(){
        if (!multiShotPickedUp){
            StartCoroutine(SpawnMultiShot());
            UiDisplay.PickedUpMultiShot();
        }
        multiShotPickedUp = true;
    }

    IEnumerator SpawnMultiShot(){
        yield return new WaitForSeconds(2.5f/multiShotFireRate);
        float division = 360f/multiShotCount;
        float angle = 360f*UnityEngine.Random.Range(0, 1f);
        for (int i = 0; i < multiShotCount; i++){
            GameObject obj = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0f,0f,angle)));
            obj.GetComponent<Bullet>().talentBullet = true;
            angle+=division;
        }
        StartCoroutine(SpawnMultiShot());
    }

    IEnumerator SpawnBeam(){
        yield return new WaitForSeconds(5f/beamSpawnRate);
        Instantiate(beam, transform.position, transform.rotation);
        StartCoroutine(SpawnBeam());
    }

    IEnumerator SpawnMine(){
        yield return new WaitForSeconds(8f/mineSpawnRate);
        mineSpawnAudio.Play();
        Instantiate(mine, transform.position, transform.rotation);
        StartCoroutine(SpawnMine());
    }
}