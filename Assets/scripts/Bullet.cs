using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int lifetime = 60;
    private bool destroyable = false;

    private float vel = 10.02f;

    private int bulletPen = 2;

    Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start() //On bullet spawn get dir and pos
    {
        if (Input.GetKey("mouse 1")){
            this.destroyable = true;
        }
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		
		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		
		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//Ta Daaa
		transform.rotation = Quaternion.Euler (new Vector3(0f,0f,angle+180));
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
            this.bulletPen--;
        }
    }
}
