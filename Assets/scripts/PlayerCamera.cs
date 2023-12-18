using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
 public float movementSpeed;
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        this.x = Input.GetAxis("Horizontal");
        this.y = Input.GetAxis("Vertical");

        transform.Translate(this.x * movementSpeed, this.y * movementSpeed, 0);
    }
}
