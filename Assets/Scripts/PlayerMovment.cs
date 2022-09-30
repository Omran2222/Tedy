using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //publi SoundManager Sm;

    
    [SerializeField] private float Speed;
    private Rigidbody RgB;

    


    private void Start()
    {
        RgB = GetComponent<Rigidbody>();
        
       
    }
    private void Update()
    {
        Vector2 InputMouse = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
        float YRotation = transform.rotation.eulerAngles.y + InputMouse.x;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, YRotation , transform.rotation.eulerAngles.z);
        

        float Horizontal = Input.GetAxis("Horizontal")*Speed;
        float Vertical = Input.GetAxis("Vertical")*Speed;


        Vector3 Movement = transform.rotation* new Vector3(Horizontal,0,Vertical);
        Movement = transform.right* Horizontal+ transform.forward * Vertical;
        
        RgB.velocity = new Vector3(Movement.x, RgB.velocity.y ,Movement.z);
        
        
        
        


        Jump();

        

    
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;

        
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
           
            RgB.AddForce(transform.up * 200);

           // Sm.PlayPlayerJump();
        }
        
    }

      


 
}
