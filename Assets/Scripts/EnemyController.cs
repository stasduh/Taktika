using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navComponent;

    private GameObject goHealth;
    private GameObject gokilling;
    private GameObject goGold;

    public int damage = 1;
    public int xp = 5;
    public int enemyCost = 2;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = gameObject.GetComponent<NavMeshAgent>();

        goHealth = GameObject.Find("Health");
        gokilling = GameObject.Find("Killing");
        goGold = GameObject.Find("Gold");
    }

    private void FixedUpdate()
    {
        navComponent.SetDestination(target.position);

        if (xp <= 0)
        {
            Destroy(gameObject); // xp is over, Enemy must destroy
            UIControllerSingleton uiController = UIControllerSingleton.getInstance();
            ++uiController.killingCount;
            uiController.gold += enemyCost;
            gokilling.GetComponent<Text>().text = string.Format("Killing: {0}", uiController.killingCount);
            goGold.GetComponent<Text>().text = string.Format("Gold: {0}", uiController.gold);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            UIControllerSingleton uiController = UIControllerSingleton.getInstance();
            uiController.playerHealth -= damage;
            goHealth.GetComponent<Text>().text = string.Format("Health {0}", uiController.playerHealth);
        }      
    }
}
