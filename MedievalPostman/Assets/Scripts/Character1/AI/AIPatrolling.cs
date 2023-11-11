using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AIPatrolling : AIBehvaiour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float stoppingDistance = 1;
    [SerializeField] private NavMeshAgent agent;

    [Space]
    [ReadOnly, SerializeField] private int curWaypointIndex;

    public override void OnEnterLogic()
    {
        agent.speed = moveSpeed;
        agent.stoppingDistance = stoppingDistance;

        agent.SetDestination(waypoints[curWaypointIndex].position);
    }

    public override void OnUpdateLogic()
    {
        if (Vector3.Distance(transform.position, waypoints[curWaypointIndex].position) <= stoppingDistance)
        {
            curWaypointIndex++;

            if (curWaypointIndex >= waypoints.Length)
            {
                curWaypointIndex = 0;
            }

            agent.SetDestination(waypoints[curWaypointIndex].position);
        }
    }
}
