using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossOne : MobBaseline
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject minePrefab;
    public float fireRate = 700f;
    private float currentRate = 0f;

    //Mechanic 1, spin around fire fast
    private const float spinSpeed = 1f;
    private const float oneFireRate = 10f;
    private float oneCurrRate = 0f;
    private int oneCount = 0;
    private bool castingOne = false;

    //Mechanic 2, throw mines
    private const float twoFireRate = 50f;
    private float twoCurrRate = 0f;
    private int twoCount = 0;
    private bool castingTwo = false;
    private bool casting = false;
    public static bool shieldDown = false;
    public static GameObject shield;// = GameObject.Find("boss1-shield");
    public int shieldRechargeDelay = 0;

    //Mechanic 33
    [SerializeField]
    private GameObject frontalPrefab;

    private bool castingThree = false;
    private bool castInitiated = false;

    private int mechanicIndex = 0;

    public void ChasePlayer(){
        float playerX = player.GetX();
        float playerY = player.GetY();
        float mobX = transform.position.x;
        float mobY = transform.position.y;
        //Debug.Log("Player: " + playerX + "," + playerY + " | Mob: " + mobX + "," + mobY);
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
		transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        if (!inRange)
        {
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * -1;
        }
        else
        {
            this.m_Rigidbody.velocity = movementDirection * 0;
            
        }
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    IEnumerator ToggleShield(){
        yield return new WaitForSeconds(0.3f);
        shield.SetActive(!shieldDown);
    }

    IEnumerator EnableShield(){
        yield return new WaitForSeconds(0.3f);
        shield.GetComponent<Animator>().SetBool("Disabled", false);
    }

    public void DisableShield(){
        if (!shieldDown){
            shieldDown = true;
            isImmune = false;
            shield = GameObject.Find("boss1-shield");
            shield.GetComponent<Animator>().SetBool("Disabled", true);
            StartCoroutine(ToggleShield());
        }
    }

    void ActivateShield(){
        if (shieldDown){
            shieldDown = false;
            isImmune = true;
            //GameObject shield = GameObject.Find("boss1-shield");
            shield.SetActive(true);
            StartCoroutine(EnableShield());
        }
    }

    void mechanicOne(){
        transform.Rotate(new Vector3 ( 0, 0, Time.deltaTime * 60f * spinSpeed));
        if (oneCurrRate <= 0){
            Vector3 pos = transform.position;
            pos.z += 0.5f;
            float rotation = 0f;
            for(int i = 0; i<3; i++){
                GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
                bullet.GetComponent<MobBullet>().vel = 7f;
                bullet.GetComponent<MobBullet>().lifetime = 300;
                bullet.transform.Rotate(new Vector3 ( 0, 0, rotation));
                rotation += 120f;
            }
            oneCurrRate = oneFireRate;
        }else {
            oneCurrRate--;
        }
    }

    void mechanicTwo(){
        if (twoCurrRate <= 0){
            Vector3 pos = transform.position;
            pos.z += 0.5f;
            //Spawn shit
            Instantiate(minePrefab, transform.position, transform.rotation);
            twoCurrRate = twoFireRate;
        }else{
            twoCurrRate--;
        }
    }

    void SpawnFrontal(Vector3 position){
        GameObject obj = Instantiate(frontalPrefab, position, Quaternion.identity);
        obj.transform.parent = transform;
        obj.transform.rotation = transform.rotation;
        obj.transform.localScale = new Vector3(-0.2f, -20f, 1f);
    }

    List<Vector3> GetPositions(List<Vector3> pos, int count){
        count--;
        if (count == 0) return pos;
        int removeIndex = UnityEngine.Random.Range(0, pos.Count);
        pos.RemoveAt(removeIndex);
        return GetPositions(pos, count);
    }

    void mechanicThree(){
        Vector3 currPos = transform.position;
        currPos.z -= 0.5f;
        Vector3[] positions = {
            currPos + transform.up * 8f, 
            currPos + transform.right * 3.8f + transform.up * 6.5f, 
            currPos + transform.right * 7.4f + transform.up * 5.5f, 
            currPos + transform.right * -3.8f + transform.up * 6.5f, 
            currPos + transform.right * -7.4f + transform.up * 5.5f
        };
        // shoot 2-4 frontals from barrels
        int count = UnityEngine.Random.Range(2, 5);
        List<Vector3> pos = GetPositions(new List<Vector3>(positions), count);
        foreach(Vector3 position in pos){
            SpawnFrontal(position);
        }
    }

        public IEnumerator CastComplete(){
        yield return new WaitForSeconds(1.6f);
        casting = false;
        castingThree = false;
        castInitiated = false;
        m_Rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!casting){
            this.ChasePlayer();
        }
        
        if (inRange && this.currentRate <= 0 && !casting)
        {   
            int[] mechanics = {0,1,2,0,0,1,1,2,0,2,1};
            //Mechanics here
            //Fire
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            this.currentRate = fireRate;
            casting = true;
            int mechanic = mechanics[mechanicIndex];
            mechanicIndex++;
            if(mechanicIndex == mechanics.Length) mechanicIndex = 0;

            if ( mechanic == 0){
                castingOne = true;
            } else if (mechanic == 1){
                if (shieldDown && shieldRechargeDelay <= 0) {
                    ActivateShield();
                    casting = false;
                    m_Rigidbody.constraints = RigidbodyConstraints2D.None;
                    shieldRechargeDelay = 3;
                } else {
                    shieldRechargeDelay--;
                    castingTwo = true;
                }

            }else if (mechanic == 2){
                castingThree = true;
            }

        } else if (casting && castingOne){
            if (oneCount <= 600){
                mechanicOne();
                oneCount++;
            }else{
                casting = false;
                castingOne = false;
                oneCount = 0;
                m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            }
        } else if (casting && castingTwo){
            if (twoCount <= 50){
                mechanicTwo();
                twoCount++;
            }else{
                twoCount = 0;
                casting = false;
                castingTwo = false;
                m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            }

        } else if (casting && castingThree){
            if (!castInitiated) {
                castInitiated = true;
                mechanicThree();
                StartCoroutine(CastComplete());
            }
        } else
        {
            this.currentRate--;
        }

        if (health <= 0 && alive){
            this.Die();
        }
    }

}
