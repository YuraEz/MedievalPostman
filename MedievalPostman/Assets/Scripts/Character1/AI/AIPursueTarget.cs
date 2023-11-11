using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPursueTarget : AIBehvaiour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float enemyCheckDst;

    [Space]
    [SerializeField] private float pursueSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AttackHandler attackHandler;

    [Space]
    [ReadOnly, SerializeField] private Collider enemy;

    public override void OnInit()
    {
        attackHandler.Init();
    }

    public override bool OnCheckEnter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyCheckDst, enemyLayer);

        if (colliders.Length > 0)
        {
            enemy = colliders[0];
            return true;
        }

        return false;
    }

    public override void OnEnterLogic()
    {
        agent.stoppingDistance = attackDistance;
        agent.speed = pursueSpeed;
    }

    public override void OnUpdateLogic()
    {
        agent.SetDestination(enemy.transform.position);

        if (Vector3.Distance(transform.position, enemy.transform.position) <= attackDistance)
        {
            agent.isStopped = true;
            attackHandler.TryAttack(enemy.transform.position);
            //Vector3 dir = enemy.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(dir);
        }
        else
        {
            agent.isStopped = false;
        }
    }
}
