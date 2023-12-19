using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim.GetBool("Walking"));
    }
    void Print(){
        Debug.Log(anim.GetBool("Walking"));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            //Debug.Log("walkingggg");
            anim.SetBool("Walking", true);
        }else{
            anim.SetBool("Walking", false);
        }
    }
}
