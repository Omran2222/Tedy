using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonOrGun : MonoBehaviour
{
    [SerializeField]private Transform BulletSpawnPoints;
    [SerializeField]private GameObject Bullet;
    
    void Update()
    {
      if(Input.GetButtonDown("Fire1"))
      {
        Instantiate(Bullet, BulletSpawnPoints.position, transform.rotation);
      }  
    }
}
