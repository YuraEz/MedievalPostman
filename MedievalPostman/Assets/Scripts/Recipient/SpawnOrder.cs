using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SpawnOrder : MonoBehaviour
{
    [SerializeField] private Transform startItem;
    [ReadOnly ,SerializeField] private List<PovozkaItem> items;

    public static SpawnOrder Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(PovozkaItem item)
    {
        print("AddItem");
        items.Add(item);
        item.transform.SetParent(transform);
        item.transform.position = startItem.transform.position + new Vector3(0, items.Count);
        item.Rb.isKinematic = true;
    }
}
