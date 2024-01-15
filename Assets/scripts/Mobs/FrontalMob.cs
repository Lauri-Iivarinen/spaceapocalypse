using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrontalMob : MonoBehaviour, MobActions
{
    [SerializeField]
    private GameObject frontalPrefab;
    public float health = 1000f; //While hitreg issue continues, mob health is doubled from 5 to 10
    public Player player;
    Rigidbody2D m_Rigidbody;
    public float mobSpeed = 4.0f;
    Animator anim;
    bool alive = true;
    public float damage;
    public bool inRange = false;
    public float fireRate = 250f;
    private float currentRate = 0f;
    [SerializeField]
    private GameObject healthPickup;
    public int XPREWARD = 20;
    [SerializeField]
    private GameObject dmgTxt;
    private bool casting = false;
    public float castTime;

    public void TakeDamage(float dmg, bool crit){
        this.health -= dmg;
        DisplayDamage(dmg, crit);
    }

    public float GetDamage(){
        return 0f;
    }

    public void SetInRange(bool range){
        inRange = range;
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
        float mobX = transform.position.x;
        float mobY = transform.position.y;
        //Debug.Log("Player: " + playerX + "," + playerY + " | Mob: " + mobX + "," + mobY);
		float angle = AngleBetweenTwoPoints(new Vector2(transform.position.x, transform.position.y), new Vector2(playerX, playerY));
		transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle));
        Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
        if (!inRange)
        {
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * -1;
        }
        else
        {
            this.m_Rigidbody.velocity = movementDirection * this.mobSpeed * 0;
        }
        transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x,transform.rotation.y,angle+90));
    }

    public IEnumerator CastComplete(){
        yield return new WaitForSeconds(castTime+0.1f);
        this.casting = false;
    }

    void StartCast(){
        this.casting = true;
        Instantiate(frontalPrefab, transform.position, transform.rotation);
        StartCoroutine(CastComplete());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!this.casting){
            this.ChasePlayer();
        }

        if (inRange && this.currentRate <= 0)
        {
            StartCast();  
            this.currentRate = fireRate;
        } else
        {
            if (!casting){
                this.currentRate--;
            }
            
        }

        if (health <= 0 && alive){
            this.Die();
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
