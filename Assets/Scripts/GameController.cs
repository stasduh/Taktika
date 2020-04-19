using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject goCost;
    public GameObject goHealth;
    public int cost = 10;
    public int health = 10;

    public float waveDelay = 10f;
    private float nextWaveTime;

    private float nextSpawnTime;
    private float spawnDelay = 1f;
    private Transform[] spawnArray = new Transform[3];

    // Start is called before the first frame update
    void Start()
    {
        goCost.GetComponent<Text>().text = string.Format("Cost: {0}", cost);
        goHealth.GetComponent<Text>().text = string.Format("Health: {0}", health);

        UIControllerSingleton uiController = UIControllerSingleton.getInstance();
        uiController.playerHealth = health;

        GameObject[] allSpawn = GameObject.FindGameObjectsWithTag("Spawn");

        for (int i = 0; i <= allSpawn.Length - 1; i++)
        {
            spawnArray[i] = allSpawn[i].transform; 
        }

        nextWaveTime = Time.time + waveDelay;
    }

    private void FixedUpdate()
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
        int i = random.Next(0, 3);

        if (ShouldIncreaseEnemy())
        {
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            ++enemyController.damage;
            ++enemyController.xp;
            ++enemyController.enemyCost;

            NavMeshAgent navComponent = enemy.GetComponent<NavMeshAgent>();
            ++navComponent.speed;

            nextWaveTime = Time.time + waveDelay;
        }

        Instantiate(enemy, spawnArray[i].transform.position, spawnArray[i].transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }

    private bool ShouldIncreaseEnemy()
    {
        return Time.time > nextWaveTime;
    }

}
