using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    private float nextSpawnTime;
    public float spawnDelay = 5;
    private Transform[] spawnArray = new Transform[3];

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allSpawn = GameObject.FindGameObjectsWithTag("Spawn");

        for (int i = 0; i <= allSpawn.Length - 1; i++)
        {
            spawnArray[i] = allSpawn[i].transform; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }   
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        System.Random random = new System.Random();
        int i = random.Next(0, 2); 
        Instantiate(enemy, spawnArray[i].transform.position, spawnArray[i].transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }
}
