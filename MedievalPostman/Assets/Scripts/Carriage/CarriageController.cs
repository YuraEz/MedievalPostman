using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarriageController : MonoBehaviour
{
    private Transform[] waypoints; // ������ ��� �������� ���� �����, ������� ��� ������ ��������
    [SerializeField] private int ChosenRoad;
    private int currentWaypointIndex = 0; // ������ ������� �����


    [SerializeField] private float moveSpeed = 5f; // �������� �������� ����
    [SerializeField] private float Healths;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private LayerMask CarriageMask;
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private float AttackRange;
    [SerializeField] private Transform eye;

    [SerializeField] private Animator animator;

    //[SerializeField] private carr
    private CarriageInventory inventory;


    void Start()
    {
        animator.SetBool("Move", true);
        inventory = CarriageInventory.Instance;
        if (ChosenRoad == 1)
        {
            waypoints = CarriageSpawner.Instance.WayPoints1;
            return;
        }
        waypoints = CarriageSpawner.Instance.WayPoints2;
        MoveToWaypoint(waypoints[currentWaypointIndex]);
    }


    void Update()
    {
        Ray ray = new Ray(eye.position, eye.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, AttackRange, CarriageMask))
        {
            animator.SetBool("Move", false);
            return;
        }
        if (Physics.Raycast(ray, out hit, AttackRange, PlayerMask))
        {
            animator.SetBool("Move", false);
            inventory.GiveItem();
            return;
        }
        animator.SetBool("Move", true);

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 2f)
        {

            // ���� ������, ��������� � ��������� �����
            currentWaypointIndex++;

            // ���� �������� ������, ������������� ������� ������
            if (currentWaypointIndex >= waypoints.Length)
            {
                enabled = false;
                Destroy(gameObject);
                return;
            }

            // � ��������� ������, ���������� ��������� � ��������� �����

        }
        MoveToWaypoint(waypoints[currentWaypointIndex]);
    }

    private void MoveToWaypoint(Transform waypoint)
    {
        // ���������� ��� � ��������� �����
        Vector3 direction = (waypoint.position - transform.position);


        Quaternion LookRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRot, Time.deltaTime * rotationSpeed);
    }

    public void TakeDamage(float damageAmount)
    {
        Healths -= damageAmount;

        if (Healths < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(eye.position, eye.forward * AttackRange);
    }
}
