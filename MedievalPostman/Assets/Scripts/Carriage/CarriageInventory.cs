using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageInventory : MonoBehaviour
{ 
    [SerializeField] private Transform startItem;
    [SerializeField] private LayerMask itemsLayer;

    [SerializeField] private List<PovozkaItem> items;

    private Inventory inventory;

    public static CarriageInventory Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        inventory = Inventory.Instance;
        TurnColliderOff();
    }

    public void TurnColliderOff()
    {
        foreach (PovozkaItem item in items)
        {
            item.Rb.isKinematic = true;
            item.GetComponent<Collider>().enabled = false; // Отключаем коллайдер
        }
        // Затем продолжайте изменения kinematic
        // ...
        // После завершения всех изменений:
        //foreach (PovozkaItem item in items)
        //{
        //    item.GetComponent<Collider>().enabled = true; // Включаем коллайдер обратно
        //}
    }

    public void GiveItem()
    {
        print("GiveItem");
        List<PovozkaItem> itemsToRemove = new List<PovozkaItem>();

        foreach (PovozkaItem item in items)
        {
            item.Rb.isKinematic = false;
            itemsToRemove.Add(item);
            //Destroy(item.gameObject);
        }

        foreach (PovozkaItem itemToRemove in itemsToRemove)
        {
            items.Remove(itemToRemove);
            inventory.AddItem(itemToRemove);
        }
    }

}
