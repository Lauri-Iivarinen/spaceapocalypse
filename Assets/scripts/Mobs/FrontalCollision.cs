using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontalCollision : MonoBehaviour
{
    private bool collisionActive = false;
    public float damage;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CastComplete());
    }

    public IEnumerator CastComplete(){
        yield return new WaitForSeconds(duration);
        this.collisionActive = true;
    }

    void OnTriggerStay2D(Collider2D obj){
        if(collisionActive && obj.gameObject.name.Contains("Player")){
            Debug.Log("Hit");
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
