using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrontalMob : MobBaseline
{
    [SerializeField]
    private GameObject frontalPrefab;

    public float fireRate = 250f;
    private float currentRate = 0f;
    private bool casting = false;
    public float castTime;
    private GameObject currentCast;

    public void ChasePlayer(){
        m_Rigidbody.constraints = RigidbodyConstraints2D.None;
        float playerX = player.GetX();
        float playerY = player.GetY();
        float mobX = transform.position.x;
        float mobY = transform.position.y;
        //Debug.Log("Player: " + playerX + "," + playerY + " | Mob: " + mobX + "," + mobY);
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        if (!inRange){
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * -1;
        }else {
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * 0;
        }

        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    public IEnumerator CastComplete(){
        yield return new WaitForSeconds(castTime+0.1f);
        this.casting = false;
    }

    void StartCast(){
        this.casting = true;
        currentCast = Instantiate(frontalPrefab, transform.position, transform.rotation);
        StartCoroutine(CastComplete());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (casting){
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }else{
            this.ChasePlayer();
        }

        if (inRange && this.currentRate <= 0)
        {
            StartCast();  
            this.currentRate = fireRate;
        } else
        {
            if (!casting){
                this.currentRate--;
            }
            
        }

        if (health <= 0 && alive){
            this.Die();
        }
    }
}
