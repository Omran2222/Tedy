using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem ParticleBlood;
    List<ParticleCollisionEvent> CollisionEvents = new List<ParticleCollisionEvent>();
    [SerializeField]private float BulletLifeSpan;
    private Rigidbody RB;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        Invoke("Delete", BulletLifeSpan);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        int events = ParticleBlood.GetCollisionEvents(other, CollisionEvents);

        Debug.Log("It's Work");
        for (int i = 0; i <= events; i++)
        {

        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            ParticleBlood.Play();

        }
        //Destroy(gameObject);
    }


   
}
