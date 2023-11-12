using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform PlayerCamera;

    public static CameraShaker instance;

    private void Awake()
    {
        instance = this;
    }

    [ContextMenu("Shake")]
    public void CameraShake(float strenght)
    {
        PlayerCamera.DOShakeRotation(1, strenght);
    }

}
