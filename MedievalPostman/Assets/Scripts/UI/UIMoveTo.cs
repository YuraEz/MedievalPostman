using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoveTo : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float duration;

    private void Start()
    {
        transform.DOMove(target.position, duration);
    }
}
