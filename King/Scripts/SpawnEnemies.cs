using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private Vector2 punto1;
    private Vector2 punto2;
    private Vector2 punto3; 

    void Start()
    {
        punto1 = new Vector2(8.6f,6.5f);
        punto2 = new Vector2(13.8f, 6.5f);
        punto3 = new Vector2(20.6f, 6.5f);

        InvokeRepeating("CreateEnemies", 2, 1);
    }

    private void CreateEnemies()
    {
       int aleatorio=Random.Range(0, 2);
        Vector2 position;
        position = punto1;

        if (aleatorio == 0) position = punto1;
        if (aleatorio == 1) position = punto2;
        if (aleatorio == 2) position = punto3;

        Instantiate(enemyPrefab,position, transform.rotation);
    }
}
