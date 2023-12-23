using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int lifetime = 60;
    private float vel = 10.02f;
    private int bulletPen = 2;
    private float damage;
    Rigidbody2D m_Rigidbody;
    public ClassSpecs specs;
    Animator anim;
    public bool destroyed = false;

    void Start() //On bullet spawn get dir and pos
    {
        anim = GetComponent<Animator>();
        this.getWeaponSpecs();
        m_Rigidbody = GetComponent<Rigidbody2D>();
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler (new Vector3(0f,0f,angle+180));
        transform.TransformDirection(Vector3.forward * 10);
    }

    private void getWeaponSpecs(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        this.specs = pl.activeClass;
        this.lifetime = this.specs.projectileLifetime;
        this.bulletPen = this.specs.penetration;
        this.vel = this.specs.projectileSpeed;
        this.damage = this.specs.weaponDamage;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    IEnumerator ExplodeGameObject(){
        anim.SetBool("Contact", true);
        
        yield return new WaitForSeconds(0.2f);
        DestroyGameObject();
    }

    void FixedUpdate(){
        if (destroyed){
             Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
            m_Rigidbody.velocity = movementDirection * 1f;
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
        if (!objectName.gameObject.name.Contains("Player") && !objectName.gameObject.name.Contains("RangeFinder"))
        {
            this.bulletPen--; //if bullet has penetration power
        }
    }
}
