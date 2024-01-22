using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineRadiusController : MonoBehaviour
{
    // Start is called before the first frame update
    List<Collider2D> mobsInRange = new List<Collider2D>();
    Rigidbody2D m_Rigidbody;
    public bool active = false;
    private bool exploded = false;
    private float mineSpeed = 6f;
    private int movementLifetime;
    public static float explosionRadius = 1f;

    CircleCollider2D coll;
    
    void Start(){
        this.coll = GetComponent<CircleCollider2D>();
        movementLifetime = (int)((50 + 100*UnityEngine.Random.Range(0, 1f))/2);
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
        //Get random distance where mine is "thrown"
        float rotZ = UnityEngine.Random.Range(0, 1f)*360;
        Vector3 rot = new Vector3(transform.rotation.x, transform.rotation.y, rotZ);
        transform.Rotate(rot);
        coll.radius *= explosionRadius;
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

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("Mob") && !obj.gameObject.name.Contains("Bullet") && !exploded && active){
            if (!mobsInRange.Contains(obj)) mobsInRange.Add(obj);
        }
    }

    void OnTriggerExit2D(Collider2D obj){
        if(obj.gameObject.name.Contains("Mob") && !obj.gameObject.name.Contains("Bullet")){
            mobsInRange.Remove(obj);
        }
    }

    IEnumerator DestroySprite(){
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    public void Explode(){
        StartCoroutine(DestroySprite());
        if (!exploded){
            foreach (Collider2D obj in mobsInRange){
                //What happens if mob is in radius but is killed before explosion?
                //Fast manual testing says nothing, dig further.
                MobActions mob = obj.GetComponent<MobActions>();
                mob.TakeDamage(Mine.damage, Mine.crit);
            }
            exploded = true;
        }
    }
}
