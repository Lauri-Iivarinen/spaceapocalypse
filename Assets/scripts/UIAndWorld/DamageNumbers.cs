using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class DamageNumbers : MonoBehaviour
{
    private int lifetime;
    // Start is called before the first frame update
    void Start()
    {
        this.lifetime = 50;   
    }

    void SetGlobalScale (Vector3 globalScale)
    {
        transform.localScale = Vector3.one;
        transform.localScale = new Vector3 (globalScale.x/transform.lossyScale.x, globalScale.y/transform.lossyScale.y, globalScale.z/transform.lossyScale.z);
    }

    void FixedUpdate(){
        if (this.lifetime <= 0){
            Destroy(gameObject);
        }
        Quaternion rot = transform.rotation;
        rot.z = 0;
        transform.rotation = rot;
        this.lifetime--;
        transform.position = new Vector3(transform.position.x, transform.position.y+0.05f);
        SetGlobalScale(new Vector3(0.5f, 0.5f, 0.5f));
    }
    
}
