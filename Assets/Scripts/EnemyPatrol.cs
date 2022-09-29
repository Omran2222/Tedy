using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent NMAgent;
    [SerializeField]private float AttackRadius;

    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float Distance = Vector3.Distance(transform.position,player.position);
        if(Distance < AttackRadius)
        {
            NMAgent.SetDestination(player.position);
        }
    }
    
}
