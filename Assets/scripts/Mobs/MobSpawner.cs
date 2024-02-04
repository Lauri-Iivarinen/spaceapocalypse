using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mobOne;
    [SerializeField]
    private GameObject mobTwo;
    [SerializeField]
    private GameObject mobThree;
    [SerializeField]
    private GameObject mobFour;
    [SerializeField]
    private GameObject mobFive;
    [SerializeField]
    private GameObject mobBoss;
    [SerializeField]
    private float spawnInterval = 4f;
    public Player player;
    private float playerX = 0;
    private float playerY = 0;
    public float maxX;
    public float maxY;
    private GameObject activeMob;
    private List<GameObject> mobs;
    public static int waveIndex = 0;
    private bool spawnBoss = false;
    public float waveDuration = 60f;
    // Wave (mobIndex, mobCount)
    static (int,int)[] wave1 = {(0, 4)};
    static (int, int)[] wave2 = {(0, 3), (1, 2)};
    static (int, int)[] wave3 = {(0, 3), (2, 3)};
    static (int, int)[] wave4 = {(2, 3), (1, 3), (4, 1)};
    static (int, int)[] wave5 = {(0, 2), (2, 3), (3, 3)};
    static (int, int)[] wave6 = {(2, 4), (1, 4), (4, 1)};
    static (int, int)[] wave7 = {(0, 3), (2, 3), (1, 2), (3, 2)};
    static (int, int)[] wave8 = {(0, 3), (1, 3), (2, 3), (3, 2), (4, 2)};

    private List<(int, int)[]> mobOrder = new List<(int, int)[]>(){
        wave1, wave2, wave3, wave4, wave5, wave6, wave7, wave8
    };

    public static int waveCount = 8;

    // Start is called before the first frame update
    void Start()
    {
        waveIndex = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
        GameObject[] mobArr = {mobOne, mobTwo, mobThree, mobFour, mobFive};
        mobs = new List<GameObject>(mobArr);
        StartCoroutine(spawnMob());
        StartCoroutine(changeWave());
        waveCount = mobOrder.Count;
    }

    //Makes mobs spawn outside player screen
    private Vector2 calcRange(){
        float aspect = (float)Screen.width / Screen.height;
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * aspect;
        float x = player.GetX();
        float y = player.GetY();
        float bossExtra = 0;
        if (spawnBoss) bossExtra = 50f;

        //roll which side, then roll on the side
        int res = UnityEngine.Random.Range(0, 4);

        if(res == 0){//Above
            y += worldHeight/1.8f+bossExtra;
            x = x+worldWidth/2*UnityEngine.Random.Range(-1f, 1);
        }else if (res == 1){//Below
            y -= worldHeight/1.8f-bossExtra;
            x = x+worldWidth/2*UnityEngine.Random.Range(-1f, 1);
        }
        else if (res == 2){//Left
            x -= worldWidth/1.8f-bossExtra;
            y += worldHeight/2*UnityEngine.Random.Range(-1f, 1);
        }
        else if (res == 3){//right
            x += worldWidth/1.8f+bossExtra;
            y += worldHeight/2*UnityEngine.Random.Range(-1f, 1);
        }

        return new Vector2(x,y);
    }

    private IEnumerator changeWave(){
        yield return new WaitForSeconds(waveDuration);
        waveIndex++;
        if (waveIndex >= mobOrder.Count) spawnBoss = true;
        else{
            StartCoroutine(changeWave());
        }
    }

    private IEnumerator spawnBossAfterDelay(){
        yield return new WaitForSeconds(1f);
        GameObject obj = Instantiate(mobBoss, calcRange() , Quaternion.identity);
        obj.GetComponent<MobBaseline>().isImmune = true;
    }

   private IEnumerator spawnMob(){
        yield return new WaitForSeconds(spawnInterval);
        if (!spawnBoss){
            (int, int)[] mobIndexes = mobOrder[waveIndex];
            foreach ((int, int) i in mobIndexes){
                for (int j = 0; j < i.Item2; j++){
                    Instantiate(mobs[i.Item1], calcRange() , Quaternion.identity);
                }
            }
            StartCoroutine(spawnMob());
        }else{
            StartCoroutine(spawnBossAfterDelay());
        }
        
   }

   void FixedUpdate(){
        //Record player pos
        this.playerX = Input.GetAxis("Horizontal");
        this.playerY = Input.GetAxis("Vertical");
   }
}
