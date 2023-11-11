using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    public Transform Target { get => target; }
}
