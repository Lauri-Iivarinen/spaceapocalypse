using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int lifetime = 60;
    private float vel = 10.02f;
    private int bulletPen = 2;
    public float damage;
    Rigidbody2D m_Rigidbody;
    public ClassSpecs specs;
    Animator anim;
    public bool destroyed = false;
    private bool crit = false;
    public bool talentBullet = false;

    void Start() //On bullet spawn get dir and pos
    {
        anim = GetComponent<Animator>();
        this.getWeaponSpecs();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        transform.TransformDirection(Vector3.forward * 10);
    }

    private int GetPenetration(Player pl, int pen){
        return pen + pl.stats.GetPenetration();
    }

    private void getWeaponSpecs(){
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        this.specs = pl.activeClass;
        this.lifetime = this.specs.projectileLifetime;
        this.bulletPen = GetPenetration(pl, this.specs.penetration);
        this.vel = this.specs.projectileSpeed;
        //Calc if bullet crits and if so whats the damage
        if ( UnityEngine.Random.Range(0, 1f) < pl.stats.critChance){ //Crit chance 10% = 0.1f
            damage = this.specs.weaponDamage * pl.stats.damageMultiplier * pl.stats.critDamageMultiplier;
            this.crit = true;
        }else{
            damage = this.specs.weaponDamage * pl.stats.damageMultiplier;
        }

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
        if (objectName.gameObject.name.Contains("shield")){
            this.bulletPen = 0;
            this.damage = 0;
        }
        if (objectName.gameObject.name.Contains("Mob") && !objectName.gameObject.name.Contains("MobBullet"))
        {
            if (talentBullet) damage = TalentController.bulletDamage;
            MobActions mob = objectName.gameObject.GetComponent<MobActions>();
            mob.TakeDamage(this.damage, this.crit);
            this.bulletPen--; //if bullet has penetration power
        }else if (objectName.gameObject.name.Contains("rock")){
            this.bulletPen--;
        }
    }
}
