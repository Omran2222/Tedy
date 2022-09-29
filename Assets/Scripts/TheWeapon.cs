using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TheWeapon : MonoBehaviour
{
    
    [SerializeField]private float BulletSpeed;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform BulletSpawnPoint;

    

   // [SerializeField]private float BulletLifeSpan;
    
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            var Bullet = Instantiate(BulletPrefab,BulletSpawnPoint.position,BulletSpawnPoint.rotation);
            Bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * BulletSpeed;
            // RB.AddForce(transform.forward * BulletSpeed);
           
        }

       

        
    }

    



   

   
}
