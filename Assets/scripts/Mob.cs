using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mob : MonoBehaviour
{

    private float health = 10.0f; //While hitreg issue continues, mob health is doubled from 5 to 10
    public Player player;
    Rigidbody2D m_Rigidbody;
    private float mobSpeed = 4.0f;

    void OnTriggerEnter2D(Collider2D objectName)
    {
        //Debug.Log(objectName.gameObject.name);
        if (objectName != null && objectName.gameObject.name.Contains("Bullet"))
        {
            Bullet bullet = objectName.gameObject.GetComponent<Bullet>();

            if (bullet != null && bullet.specs != null && !bullet.destroyed)
            {
                this.health -= bullet.specs.weaponDamage;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Die(){
        Destroy(gameObject);
        this.player.stats.gainXp(26);
    }

    private void ChasePlayer(){
        float playerX = player.GetX();
        float playerY = player.GetY();
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
		transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * -1;
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.ChasePlayer();
        if (health <= 0){
            this.Die();
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
