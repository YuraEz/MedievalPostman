using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
    [SerializeField] private AIBehvaiour[] allBehaviours;

    [Space]
    [ReadOnly, SerializeField] private AIBehvaiour curBehaviour;

    private void Start()
    {
        foreach (var behaviour in allBehaviours)
        {
            behaviour.OnInit();
        }
    }

    private void Update()
    {
        foreach (var behaviour in allBehaviours)
        {
            if (behaviour.OnCheckEnter())
            {
                if (behaviour != curBehaviour)
                {
                    curBehaviour = behaviour;
                    curBehaviour.OnEnterLogic();
                }
                break;
            }
        }

        if (curBehaviour != null)
        {
            curBehaviour.OnUpdateLogic();
        }
    }
}
