using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageSpawner : MonoBehaviour
{

    [SerializeField] private Transform[] SpawnPoints;

    public Transform[] WayPoints1;
    public Transform[] WayPoints2;

    [SerializeField] private GameObject carriagePrefab1;
    [SerializeField] private GameObject carriagePrefab2;

    [SerializeField] private float TimeBetweenSpawn;


    public static CarriageSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnCarriage());
    }

    IEnumerator SpawnCarriage()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenSpawn);
            int randomSpawnIndex = Random.Range(0, SpawnPoints.Length); // Генерируем случайный индекс точки спавна
            int randomCarriage = Random.Range(0, 2);
            Vector3 spawnPosition = SpawnPoints[randomSpawnIndex].position; // Получаем позицию для спавна

            if (randomCarriage == 0)
            {
                Instantiate(carriagePrefab1, spawnPosition, Quaternion.identity); // Создаем зомби в заданной позиции
            }
            else
            {
                Instantiate(carriagePrefab2, spawnPosition, Quaternion.identity); // Создаем зомби в заданной позиции
            }
        }
    }

}
