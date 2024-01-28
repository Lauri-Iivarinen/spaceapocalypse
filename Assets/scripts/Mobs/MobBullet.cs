using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MobBullet : MonoBehaviour, MobActions
{
    private int lifetime = 150;
    public float vel = 5f;
    private int bulletPen = 1;
    public float damage;
    Rigidbody2D m_Rigidbody;
    public ClassSpecs specs;
    public bool destroyed = false;
    public Player player;

    public void TakeDamage(float dmg, bool crit){}

    public float GetDamage(){
        return damage;
    }

        public (float, float) GetHealth(){
        return (0f, 0f);
    }

    public void SetInRange(bool range){}

    void Start() //On bullet spawn get dir and pos
    {
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        float playerX = player.GetX();
        float playerY = player.GetY();
        //float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90f));
        //Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        //this.m_Rigidbody.velocity = movementDirection * vel * -1;
        transform.TransformDirection(Vector3.forward * 10);
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, angle + 90));
        transform.Rotate(new Vector3 ( 0, 0, 90f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    IEnumerator ExplodeGameObject(){
        yield return new WaitForSeconds(0.2f);
        DestroyGameObject();
    }

    void FixedUpdate(){
        if (destroyed){

        }else{
            Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
            m_Rigidbody.velocity = movementDirection * vel;

            lifetime--;

            if (bulletPen <= 0){
                destroyed = true;
                StartCoroutine(ExplodeGameObject());
            }else if (lifetime <= 0){
                DestroyGameObject();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D objectName)
    {
        if (objectName.gameObject.name.Equals("Player")){
            this.bulletPen--; //if bullet has penetration power
        }
    }
}
