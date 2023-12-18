using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mobPrefab;
    [SerializeField]
    private float spawnInterval = 3.5f;

    private float playerX = 0;
    private float playerY = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMob(spawnInterval, mobPrefab));
    }

    //Makes mobs spawn outside player screen
    private float calcRange(float num){
        float dist = num;
        float dice = UnityEngine.Random.Range(-1f, 1);
        float aspect = (float)Screen.width / Screen.height;
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * aspect;
        if (dice > 0){
            dist += worldWidth/2;
        }else{
            dist -= worldWidth/2;
        }
        return dist;
    }

   private IEnumerator spawnMob(float interval, GameObject mob){
        yield return new WaitForSeconds(interval);
        Instantiate(mobPrefab, new Vector2(calcRange(playerX), calcRange(playerY)), Quaternion.identity);
        StartCoroutine(spawnMob(interval, mob));
   }

   void FixedUpdate(){
        //Record player pos
        this.playerX = Input.GetAxis("Horizontal");
        this.playerY = Input.GetAxis("Vertical");
   }
}
