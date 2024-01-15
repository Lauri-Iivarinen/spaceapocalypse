using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

interface MobActions
{
    void TakeDamage(float dmg, bool crit);
    float GetDamage();

    void SetInRange(bool inRange);
}

public class Mob : MonoBehaviour, MobActions
{

    public float health = 1000f; //While hitreg issue continues, mob health is doubled from 5 to 10
    public Player player;
    Rigidbody2D m_Rigidbody;
    public float mobSpeed = 4.0f;
    Animator anim;
    bool alive = true;
    public float damage;
    [SerializeField]
    private GameObject healthPickup;
    [SerializeField]
    private GameObject dmgTxt;
    public int XPREWARD = 20;

    public void TakeDamage(float dmg, bool crit){
        this.health -= dmg;
        DisplayDamage(dmg, crit);
    }
    public void SetInRange(bool inRange){
        
    }

    public float GetDamage(){
        return damage;
    }

    void DisplayDamage(float dmg, bool crit){
        Quaternion rot = transform.rotation;
        rot.z = 0;
        var txt = Instantiate(dmgTxt, transform.position, rot, transform);
        if (crit){
            txt.GetComponent<TextMesh>().text = "" + dmg + "!";
            txt.GetComponent<TextMesh>().color = new Color(0, 100, 100, 1f);
        }else{
            txt.GetComponent<TextMesh>().text = "" + dmg;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
        this.player = GameObject.Find("Player").GetComponent<Player>();
    }

    IEnumerator DestroySprite(){
        yield return new WaitForSeconds(0.5f);
        //Roll for health drop (10%)
        if (UnityEngine.Random.Range(0, 1f) < 0.1f){
            Quaternion rot = transform.rotation;
            rot.z = 0;
            Instantiate(healthPickup, transform.position, rot);
        }
        Destroy(gameObject);
    }

    public void Die(){
        alive = false;
        anim.SetBool("Alive", alive);
        StartCoroutine(DestroySprite());
        this.player.stats.gainXp(XPREWARD);
    }

    public void ChasePlayer(){
        float playerX = player.GetX();
        float playerY = player.GetY();
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
		transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        this.m_Rigidbody.velocity = movementDirection * mobSpeed * -1;
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.ChasePlayer();
        if (health <= 0 && alive){
            this.Die();
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
