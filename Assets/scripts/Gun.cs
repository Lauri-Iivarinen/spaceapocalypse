using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

	private int fireRate = 30;
	private int gunCooldown = 0;
	public Rigidbody2D projectile;
    //https://discussions.unity.com/t/make-a-player-model-rotate-towards-mouse-location/125354/5
    void Update(){
        //Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		
		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		
		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//Ta Daaa
		transform.rotation = Quaternion.Euler (new Vector3(0f,0f,angle));
	}

	void FixedUpdate(){
		if (this.gunCooldown <= 0) {
			bool shooting = Input.GetKey("mouse 1");
			if (shooting)
			{
				this.gunCooldown = fireRate;
				// Instantiate the projectile at the position and rotation of this transform
				Rigidbody2D clone;
				clone = Instantiate(projectile, transform.position, transform.rotation);

				// Give the cloned object an initial velocity along the current
				// object's Z axis
				clone.velocity = transform.TransformDirection(Vector3.forward * 10);
			}
		}else{
			this.gunCooldown--;
		}
		
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}