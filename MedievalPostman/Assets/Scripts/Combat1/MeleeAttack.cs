using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackEffect
{
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    [SerializeField] private int maxAttacked = 1;
    [SerializeField] private LayerMask damagableLayers;

    [SerializeField] private float MaxHealth = 25;
    private float health;

    public static MeleeAttack instance;

    private void Awake()
    {
        instance = this;
    }

    public override void OnInit()
    {

    }

    //Vector3 attackPoint
    public override void OnAttack()
    {
        print("Вызвана функция");
        HealthComponent.instance.Damage(damage);
        //health = MaxHealth - damage;
        //UIProgressBar.Instance.SetValue(health);
        //Collider[] colliders = Physics.OverlapSphere(transform.position, radius, damagableLayers);
        //int attacked = 0;

        //foreach (Collider collider in colliders)
        //{
        //    attacked++;
        //    Vector3 directionToCollider = collider.transform.position - transform.position;
        //    float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);
        //    if (angleToCollider <= angle)
        //    {
        //        print("прошел первую проверку");
        //        if (collider.TryGetComponent(out HealthComponent health))
        //        {
        //            print("Нашел путь к хил компоненту");
        //            health.Damage(damage);
        //        }
        //    }
        //
        //    if (maxAttacked <= attacked) return;
        //}
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.red;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-angle / 2f, transform.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(angle / 2f, transform.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * radius);
        Gizmos.DrawRay(transform.position, rightRayDirection * radius);
    }
}
