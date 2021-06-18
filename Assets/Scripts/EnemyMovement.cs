using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform currentTarget;
    public Transform player;
    private NavMeshAgent agent;

    private float distanceFromWaypoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        CalculateDistanceFromWaypoint();

        // if near waypoint, randomize again, unless player is the target
        if (distanceFromWaypoint < 2.5f && currentTarget != player)
        {
            SetTargetWaypoint();
        }
        else if (currentTarget == player)
        {
            ChasePlayer(player.position);
        }
    }

    private void Start()
    {
        SetTargetWaypoint();
    }

    private void CalculateDistanceFromWaypoint()
    {
        //calculator of the distance
        distanceFromWaypoint = Vector3.Distance(transform.position, currentTarget.position);
    }


    public void SetTargetWaypoint()
    {
        Debug.Log("Choose a random waypoint as the next target.");
        //Get a random index from the waypoint
        int randomIndex = Random.Range(0, waypoints.Length);
        //Make sure that the current waypoint is not the same as the previous target
        while (waypoints[randomIndex] == currentTarget)
            randomIndex = Random.Range(0, waypoints.Length);
        //Set the current target
        currentTarget = waypoints[randomIndex];

        //Update the target in the NavMesh
        UpdateTarget(currentTarget.position);
    }

    private void UpdateTarget(Vector3 position)
    {
        //Update the destination based on the current waypoint target
        agent.destination = position;
    }
    
    private void ChasePlayer(Vector3 target)
    {
        //Chase code here
        agent.destination = target;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.isCaught = true;
        }
    }
}
