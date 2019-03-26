using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public float patrollTime = 3.0f;
    public float aggroRange = 10.0f;
    public Transform[] waypoints;

    private int waypointIndex;
    private float speed, agentSpeed;

    private Transform playerTransform;
    private Animator animator;
    private NavMeshAgent agent;

    private void Awake()
    {
        // animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) {
            agentSpeed = agent.speed;
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        waypointIndex = Random.Range(0, waypoints.Length);

        InvokeRepeating("Tick", 0, 0.5f);

        if (waypoints.Length > 0) {
            InvokeRepeating("Patrol", 0, patrollTime);
        }
    }

    private void Patrol()
    {
        waypointIndex = ((waypointIndex == waypoints.Length - 1) ? 0 : waypointIndex + 1);
    }

    private void Tick()
    {
        agent.destination = waypoints[waypointIndex].position;
    }
}
