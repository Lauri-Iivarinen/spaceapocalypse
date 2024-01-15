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
    public Player player;
    private float playerX = 0;
    private float playerY = 0;
    public float maxX;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(spawnMob(spawnInterval, mobPrefab));
        
    }

    //Makes mobs spawn outside player screen
    private Vector2 calcRange(){
        float aspect = (float)Screen.width / Screen.height;
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * aspect;
        float x = player.GetX();
        float y = player.GetY();

        //Near world border
        if (player.GetX() <= maxX-15 && player.GetX() >= (maxX-15) * -1)
        {
            //Roll dice
            if (UnityEngine.Random.Range(-1f, 1) > 0)
            {
                x += worldWidth / 2;
            }
            else {
                x -= worldWidth / 2;
            }
        }else if (player.GetX() >= maxX-15)
        {
            //Spawn right
            x -= worldWidth / 2;
        }
        else
        {
            //Spawn left
            x += worldWidth / 2;
        }

        if (player.GetY() <= maxY - 15 && player.GetY() >= (maxY - 15) * -1)
        {
            //Roll dice
            if (UnityEngine.Random.Range(-1f, 1) > 0)
            {
                y += worldHeight / 2;
            }
            else
            {
                y -= worldHeight / 2;
            }
        }
        else if (player.GetY() >= 85)
        {
            //Spawn below
            y -= worldHeight / 2;
        }
        else
        {
            //Spawn above
            y += worldHeight / 2;
        }

        return new Vector2(x,y);
    }

   private IEnumerator spawnMob(float interval, GameObject mob){
        yield return new WaitForSeconds(interval);
        Instantiate(mobPrefab, calcRange() , Quaternion.identity);
        StartCoroutine(spawnMob(interval, mob));
   }

   void FixedUpdate(){
        //Record player pos
        this.playerX = Input.GetAxis("Horizontal");
        this.playerY = Input.GetAxis("Vertical");
   }
}
