using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField]
    private GameObject bulletPrefab;
	private float fireRate = 30f;
	private float gunCooldown = 0f;
	public Rigidbody2D projectile;
	private Player player;
	private bool autoShoot = false;

	[SerializeField]
	private AudioSource gunSound;

	void Start(){
		Player pl = GameObject.Find("Player").GetComponent<Player>();
		this.player = pl;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.T)) autoShoot = !autoShoot;
	}

	Quaternion GetAngle(){
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		return Quaternion.Euler (new Vector3(0f,0f,angle+180));
	}

    //https://discussions.unity.com/t/make-a-player-model-rotate-towards-mouse-location/125354/5
	void FixedUpdate(){
		//Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		
		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		
		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//transform.rotation = Quaternion.Euler (new Vector3(angle -30f, -90f,90f));
		transform.rotation = Quaternion.Euler (new Vector3(0f, 0f,angle+90f));
		if (this.gunCooldown <= 0 && !this.player.switchingGun) {
			bool shooting = Input.GetKey("mouse 1");
			if (shooting || autoShoot) {
				this.fireRate = this.player.activeClass.fireRate / player.stats.attackSpeed;
				this.gunCooldown = fireRate;
				Vector3 pos = transform.position;
				pos.z = -0.5f; //Makes bullets appear "under ship, but over mobs/rocks for explosion anim"
				// Instantiate the projectile at the position and rotation of this transform
				
				Instantiate(bulletPrefab, pos, GetAngle());
				gunSound.Play();
			}
		}else{
			this.gunCooldown--;
		}
		
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}