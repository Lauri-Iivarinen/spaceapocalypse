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

        //roll which side, then roll on the side
        int res = UnityEngine.Random.Range(0, 4);

        if(res == 0){//Above
            y += worldHeight/1.8f;
            x = x+worldWidth/2*UnityEngine.Random.Range(-1f, 1);
        }else if (res == 1){//Below
            y -= worldHeight/1.8f;
            x = x+worldWidth/2*UnityEngine.Random.Range(-1f, 1);
        }
        else if (res == 2){//Left
            x -= worldWidth/1.8f;
            y += worldHeight/2*UnityEngine.Random.Range(-1f, 1);
        }
        else if (res == 3){//right
            x += worldWidth/1.8f;
            y += worldHeight/2*UnityEngine.Random.Range(-1f, 1);
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
