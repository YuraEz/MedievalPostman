using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovozkaItem : MonoBehaviour
{
    public Rigidbody Rb;
    public ParticleSystem BarrelEffect;


    public void TurnOnEffect()
    {
        BarrelEffect.Play();
        Invoke("TurnOffEffect", 1);
    }

    private void TurnOffEffect()
    {
        BarrelEffect.Stop();
    }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }
}
