using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    

    
     [SerializeField] Image Bar;
     private float HealthAmount = 1f;
    [SerializeField]private Transform SpawnPoint;
     private Rigidbody RgB;
    private playerMovement3D PlayerMovmentScript;
    private Transform enemy;
    

    private void Start()
    {
        RgB = GetComponent<Rigidbody>();
        
        
        PlayerMovmentScript = GetComponent<playerMovement3D>();
       

    }
    
    
    private void Update()
    {
        Bar.fillAmount = HealthAmount;

        if (HealthAmount <= 0)
        {
            Die();
        }

        



    }

    private void Die()
    {
        transform.position = SpawnPoint.position;
        HealthAmount = 1f;
        
    }
    

   /* private void Damage()
    {
        PlayerMovmentScript.enabled = false;

        RgB.AddForce(transform.up * 150);

       /* if(transform.position.x < enemy.position.x)
        {
            transform.Translate(Vector3.right * -500);
        }
        else
        {
            transform.Translate(Vector3.right * 450);
        }*/
          /*  Invoke("MoveAgain",1);
    }

    private void MoveAgain()
    {
        PlayerMovmentScript.enabled = true;
    }
      
    */


    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            HealthAmount--;
            enemy = collision.gameObject.transform;
            
            
               
        }
            
            

        
    }
}
