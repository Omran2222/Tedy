using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement : MonoBehaviour
{

     Animator Anim;
     playerMovement3D playerMovement3D;
     
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        playerMovement3D = GetComponent<playerMovement3D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Anim.SetFloat("Speed", 0.01f);
        }
       


        if (Input.GetButtonDown("Jump"))
        {
            Anim.SetBool("Jump",true);
            Anim.SetBool("FreeFall", true);
        }
        else
        {
            Anim.SetBool("Jump", false);
        }



       /* bool Jum = playerMovement3D.isGrounded;

        //Jump

        if (!Jum)
        {
            Anim.SetBool("Jump",true);
        }
        

        if (Jum)
        {
            Anim.SetBool("Jump", false);
        }*/

       
      
    }
}
