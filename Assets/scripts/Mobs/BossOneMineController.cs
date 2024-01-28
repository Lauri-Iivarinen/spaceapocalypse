using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneMineController : MonoBehaviour
{
    public float damage = 300f;
    public Animator anim;
    Rigidbody2D m_Rigidbody;
    public bool active = false;
    private bool exploded = false;
    private float mineSpeed = 12f;
    private int movementLifetime;
    public static float explosionRadius = 1f;


    IEnumerator DestroySprite(){
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(active && obj.gameObject.name.Contains("boss1-shield")){
            BossOne boss = GameObject.Find("Mob-boss1").GetComponent<BossOne>();
            boss.DisableShield();
            anim.SetBool("Destroyed", true);
            StartCoroutine(DestroySprite());
        }else if (active && obj.gameObject.name.Contains("Player")){
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.TakeDamage(damage);
            anim.SetBool("Destroyed", true);
            StartCoroutine(DestroySprite());
        }
    }

    void Start(){
        movementLifetime = (int)((150 + 100*UnityEngine.Random.Range(0, 1f))/2);
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
        //Get random distance where mine is "thrown"
        float rotZ = 90 + UnityEngine.Random.Range(-1f, 1f)*60;
        Vector3 rot = new Vector3(transform.rotation.x, transform.rotation.y, rotZ);
        transform.Rotate(rot);
        anim = GetComponent<Animator>();
    }

    void FixedUpdate(){
        //Moves for 1-3 seconds in a random direction before activating (ready to blow)
        if (!active){
            movementLifetime--;
            Vector2 movementDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z));
            this.m_Rigidbody.velocity = movementDirection * mineSpeed;
            if (movementLifetime <= 0) {
                active = true;
                m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        if (exploded){
            transform.localScale *= 1.1f;
        }
    }
}
