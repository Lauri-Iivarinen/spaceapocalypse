using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public static float speed = 1f;
    public static float beamSize = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySprite());
        transform.Rotate(new Vector3 ( 0, 0, 0));
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*beamSize, transform.localScale.z);
    }

    IEnumerator DestroySprite(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Player pl = GameObject.Find("Player").GetComponent<Player>();
        Vector3 pos = new Vector3(pl.GetX(), pl.GetY(), 0);
        transform.position = pos;
        transform.Rotate(new Vector3 ( 0, 0, Time.deltaTime * 180f * speed));
    }
}
