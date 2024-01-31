using System.Collections;
using UnityEngine;
interface MobActions
{
    void TakeDamage(float dmg, bool crit);
    float GetDamage();
    void SetInRange(bool inRange);

    (float, float) GetHealth();
}

public class MobBaseline : MonoBehaviour, MobActions{

    public bool boss = false;
    public string mobName = "";
    public float health = 0;
    public float damage = 0;
    public float maxHealth = 0;
    public Player player;
    public Rigidbody2D m_Rigidbody;
    public Animator anim;
    public int XPREWARD = 20;
    public bool alive = true;
    [SerializeField]
    private GameObject healthPickup;
    [SerializeField]
    private GameObject dmgTxt;
    public bool inRange = false;
    public float mobSpeed = 4.0f;

    public (float, float) GetHealth(){
        return (health, maxHealth);
    }

    public void TakeDamage(float dmg, bool crit){
        this.health -= dmg;
        if (!boss) DisplayDamage(dmg, crit);
    }
    public void SetInRange(bool range){
        inRange = range;
    }

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

    public float GetDamage(){
        return damage;
    }

    void DisplayDamage(float dmg, bool crit){
        Quaternion rot = transform.rotation;
        rot.z = 0;
        var txt = Instantiate(dmgTxt, transform.position, rot, transform);
        if (crit){
            txt.GetComponent<TextMesh>().text = "" + dmg.ToString("0") + "!";
            txt.GetComponent<TextMesh>().color = new Color(0.95f, 1f, 0.1f, 1f);
        }else{
            txt.GetComponent<TextMesh>().text = "" + dmg.ToString("0");
        }
    }

    IEnumerator DestroySprite(){
        yield return new WaitForSeconds(0.5f);
        //Roll for health drop (10%) //23.1 changed to 5%
        if (UnityEngine.Random.Range(0, 1f) < 0.05f){
            Quaternion rot = transform.rotation;
            rot.z = 0;
            Instantiate(healthPickup, transform.position, rot);
        }
        Destroy(gameObject);
    }

    public void Die(){
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        alive = false;
        anim.SetBool("Alive", alive);
        StartCoroutine(DestroySprite());
        this.player.stats.gainXp(XPREWARD);
    }

    IEnumerator DisplayBossData(){
        yield return new WaitForSeconds(0.5f);
        UiDisplay display = GameObject.Find("Canvas").GetComponent<UiDisplay>();
        display.SpawnBoss(this);
    }

       void Start()
    {   
        if (boss){
            StartCoroutine(DisplayBossData());    
        }
        
        maxHealth = health;
        anim = GetComponent<Animator>();
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
        this.player = GameObject.Find("Player").GetComponent<Player>();
        //this.dmgTxt = MobObjects.dmgTxt;
        //this.healthPickup = MobObjects.healthPickup;
    }
}