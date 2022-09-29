using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleWeapon : MonoBehaviour
{

    public ParticleSystem PartiWeapon;
    List<ParticleCollisionEvent> CollisionEvents = new List<ParticleCollisionEvent>();
    // Start is called before the first frame update
    void Start()
    {
        PartiWeapon = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PartiWeapon.Play();
        }
    }
    // Update is called once per frame


    void OnParticleCollision(GameObject other)
    {
        int events = PartiWeapon.GetCollisionEvents(other, CollisionEvents);
        
        Debug.Log("It's Work");
        for (int i = 0; i <= events; i++)
        {

        }
    }
}
