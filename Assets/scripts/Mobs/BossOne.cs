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
    public float fireRate = 600f;
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
            shield = GameObject.Find("boss1-shield");
            shield.GetComponent<Animator>().SetBool("Disabled", true);
            StartCoroutine(ToggleShield());
        }
    }

    void ActivateShield(){
        if (shieldDown){
            shieldDown = false;
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
            GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
            bullet.GetComponent<MobBullet>().vel = 7f;
            GameObject bulletTwo = Instantiate(bulletPrefab, pos, transform.rotation);
            bulletTwo.GetComponent<MobBullet>().vel = 7f;
            bulletTwo.transform.Rotate(new Vector3 ( 0, 0, 120f));
            GameObject bulletThree = Instantiate(bulletPrefab, pos, transform.rotation);
            bulletThree.GetComponent<MobBullet>().vel = 7f;
            bulletThree.transform.Rotate(new Vector3 ( 0, 0, 240f));
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!casting){
            this.ChasePlayer();
        }
        
        if (inRange && this.currentRate <= 0 && !casting)
        {   
            //Mechanics here
            //Fire
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            this.currentRate = fireRate;
            casting = true;
            int mechanic = UnityEngine.Random.Range(0, 2);
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
        }else if (casting && castingTwo){
            if (twoCount <= 50){
                mechanicTwo();
                twoCount++;
            }else{
                twoCount = 0;
                casting = false;
                castingTwo = false;
                m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            }
        }else
        {
            this.currentRate--;
        }

        if (health <= 0 && alive){
            this.Die();
        }
    }

}
