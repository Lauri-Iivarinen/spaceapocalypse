using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat;
    Transform cam;
    Vector3 camStartPos;
    float distanceX;
    float distanceY;
    [Range(0f, 0.5f)]
    public float speed=1.01f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        cam = Camera.main.transform;
        camStartPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceX = cam.position.x - camStartPos.x;
        distanceY = cam.position.y - camStartPos.y;
        mat.SetTextureOffset("_MainTex", new Vector2(distanceX, distanceY) * speed);
    }
}
