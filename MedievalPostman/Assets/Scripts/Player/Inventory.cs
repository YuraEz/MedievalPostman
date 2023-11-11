using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform startItem;
    [SerializeField] private LayerMask itemsLayer;

    [SerializeField] private List<PovozkaItem> items;

    private SpawnOrder spawnOrder;
    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
        spawnOrder = SpawnOrder.Instance;
    }

    private void Start()
    {
        TurnColliderOff();
    }


    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3, itemsLayer);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out PovozkaItem item) && items.Contains(item) == false)
            {
                item.TurnOnEffect();
                items.Add(item);
                item.GetComponent<Collider>().enabled = false; // Отключаем коллайдер
                item.transform.SetParent(transform);
                item.transform.position = startItem.transform.position + new Vector3(0, items.Count);
                item.Rb.isKinematic = true;
            }
        }
    }

    public void TurnColliderOff()
    {
        foreach (PovozkaItem item in items)
        {
            item.Rb.isKinematic = true;
            item.GetComponent<Collider>().enabled = false;
        }
    }


    public void AddItem(PovozkaItem item)
    {
        print("AddItem");
        items.Add(item);
        item.transform.SetParent(transform);
        item.transform.position = startItem.transform.position + new Vector3(0, items.Count);
        item.Rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            print("GiveItem");
            List<PovozkaItem> itemsToRemove = new List<PovozkaItem>();

            //foreach (PovozkaItem item in items)
            //{
            //    ScoreManager.Instance.IncreaseScore(10);
            //    item.Rb.isKinematic = false;
            //    itemsToRemove.Add(item);
            //    Destroy(item.gameObject);
            //}

            foreach (PovozkaItem item in items)
            {
                item.Rb.isKinematic = false;
                itemsToRemove.Add(item);
                //Destroy(item.gameObject);
            }

            foreach (PovozkaItem itemToRemove in itemsToRemove)
            {
                items.Remove(itemToRemove);
                spawnOrder.AddItem(itemToRemove);
            }

            UIManager.Instance.ChangeScreen("Win");
        }
    }


}
