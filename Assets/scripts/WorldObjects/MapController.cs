using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called before the first frame update
    Player pl;
    float width;
    float height;
    void Start()
    {
        SpriteRenderer obj = GameObject.Find("backgroundBlack").GetComponent<SpriteRenderer>();
        Debug.Log(obj.bounds.size.x);
        width = obj.bounds.size.x;
        height = obj.bounds.size.y;
        //GetComponent<SpriteRenderer>().bounds.size.x;
        pl = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(pl.GetX());
        if (pl.GetX() > width + gameObject.transform.position.x){
            float xAxis = transform.position.x+width*2;
            gameObject.transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        }else if (pl.GetX() < gameObject.transform.position.x-width){
            float xAxis = transform.position.x-width*2;
            gameObject.transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        } else if (pl.GetY() > height + gameObject.transform.position.y){
            float yAxis = transform.position.y+height*2;
            gameObject.transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
        }else if (pl.GetY() < gameObject.transform.position.y-height){
            float yAxis = transform.position.y-height*2;
            gameObject.transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
        }
    }
}