using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject currentEnemy;
    public int speed = 100;
    public int forceDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (forceDamage > 1)
        {
            transform.localScale += transform.localScale;
        }
        Vector3 targetPosition = new Vector3(currentEnemy.transform.position.x, currentEnemy.transform.position.y, currentEnemy.transform.position.z);
        transform.LookAt(targetPosition);
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); // the bullet hit the target
            collision.gameObject.GetComponent<EnemyController>().xp -= forceDamage;
        }
    }
}
