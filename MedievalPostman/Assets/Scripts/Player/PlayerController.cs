using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;


public enum PlayerState { OnShip, Action }

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerEnterPoint;

    [Space]
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    [Space]
    [SerializeField] private float moveSpeed;

    [Space]
    [SerializeField] private PlayerState state;
    public ParticleSystem MoveEffect1;
    public ParticleSystem MoveEffect2;
    //[ReadOnly, SerializeField] private PlayerState state;

    private HealthComponent health;

    private ScoreManager scoreManager;
    private CameraShaker cameraShaker;

    private void Awake()
    {
        scoreManager = ScoreManager.Instance;
        cameraShaker = CameraShaker.instance;
        //health = HealthComponent.instance;
        health = GetComponent<HealthComponent>();

        health.onDie += Die;
    }
    
    private void OnDestroy()
    {
        health.onDie -= Die;
    }

    private void Die()
    {
        print("Ты умер");
        moveSpeed = 0;
        animator.SetBool("IsDead", true);
        UIManager.Instance.ChangeScreen("Lose");
        Invoke("SetActiveFalse", 2);
    }

    private void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (state != PlayerState.Action) return;

        Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        animator.SetBool("IsMove", movement != Vector3.zero);

        if (movement != Vector3.zero)
        {


            MoveEffect1.Play();
            MoveEffect2.Play();
            // Вычисляем целевой угол поворота на основе направления движения.
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Плавно интерполируем текущий угол поворота к целевому углу поворота.
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);

            // Перемещаем персонаж.
            //rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);

            rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);

            transform.rotation = Quaternion.LookRotation(movement);
        }



        //if (state != PlayerState.Action) return;

        //Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        //rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);

        //transform.rotation = Quaternion.LookRotation(movement);
        //animator.SetBool("IsMove", movement != Vector3.zero);
    }

    public void ChangeState(PlayerState newState)
    {
        state = newState;

        if (state == PlayerState.Action)
        {
            transform.position = playerEnterPoint.position;
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            print("Минус 5% целостности посылки");
            ScoreManager.Instance.UpdateScore(5);
            cameraShaker.CameraShake();
//            if (ScoreManager.Instance.ScoreValue > 3)
//            {
//                UIManager.Instance.ChangeScreen("Lose");
//            }
        }
    }

}
