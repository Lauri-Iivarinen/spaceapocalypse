using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int lifetime = 60;
    private bool destroyable = true;
    private float vel = 10.02f;
    private int bulletPen = 2;
    private float damage;
    Rigidbody2D m_Rigidbody;
    public WeaponSpecs specs;
    // Start is called before the first frame update
    void Start() //On bullet spawn get dir and pos
    {
        this.getWeaponSpecs();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler (new Vector3(0f,0f,angle+180));
        transform.TransformDirection(Vector3.forward * 10);
    }

    private void getWeaponSpecs(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        this.specs = pl.activeWeapon;
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

    void FixedUpdate(){
        if (destroyable){
            // Calculate the movement direction based on the rotation angle
            Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));

            // Set the velocity using the calculated direction
            m_Rigidbody.velocity = movementDirection * vel;
            
            lifetime--;

            if (lifetime <= 0 || bulletPen <= 0){
                DestroyGameObject();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D objectName)
    {
        if (!objectName.gameObject.name.Equals("Player")){
            this.bulletPen--; //if bullet has penetration power
        }
    }
}
