using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySprite());
        transform.Rotate(new Vector3 ( 0, 0, 0));
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
        transform.Rotate(new Vector3 ( 0, 0, Time.deltaTime * 180f));
    }
}
