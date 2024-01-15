using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontalCast : MonoBehaviour
{
    public float duration;
    public float castSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(CastComplete());
    }

    public IEnumerator CastComplete(){
        yield return new WaitForSeconds(duration+0.1f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y +castSpeed, transform.localScale.z);
    }
}
