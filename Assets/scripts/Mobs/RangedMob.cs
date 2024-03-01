using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedMob : MobBaseline
{
    [SerializeField]
    private GameObject bulletPrefab;
    public float fireRate = 90f;
    private float currentRate = 0f;


    public void ChasePlayer(){
        float playerX = player.GetX();
        float playerY = player.GetY();
        float mobX = transform.position.x;
        float mobY = transform.position.y;
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
		transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        if (!inRange)
        {
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * -1;
        }
        else
        {
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * 0;
        }
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    void FixedUpdate()
    {
        this.ChasePlayer();
        if (inRange && this.currentRate <= 0)
        {
            //Fire
            Vector3 pos = transform.position;
			pos.z = +1f;
            Quaternion rot = transform.rotation;
            rot.z += 90f;
            Instantiate(bulletPrefab, pos, transform.rotation);
            this.currentRate = fireRate;
        } else
        {
            this.currentRate--;
        }
        if (health <= 0 && alive){
            this.Die();
        }
    }

}
