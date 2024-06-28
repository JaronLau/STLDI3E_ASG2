using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform playerTransform;  // Reference to the player's transform
    [SerializeField] private float detectionRadius = 70f;
    private NavMeshAgent agent;  // Reference to the NavMeshAgent component

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found. Please ensure the player is tagged correctly.");
        }
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < detectionRadius)
            {
                ChasePlayer();
            }
            else
            {
                StopChasing();
            }
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);
    }
    void StopChasing()
    {
        agent.ResetPath();
    }
}
