using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mob : MobBaseline
{
    public void ChasePlayer(){
        float playerX = player.GetX();
        float playerY = player.GetY();
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
		transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        m_Rigidbody.velocity = movementDirection * mobSpeed * -1;
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.ChasePlayer();
        if (health <= 0 && alive){
            Die();
        }
    }
}
