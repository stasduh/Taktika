using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject barrel;
    public GameObject balletSpawn;
    public int speed = 100;
    public int forceDamage = 1;

    private GameObject enemy;   
    private float nextKillTime;

    private void FixedUpdate()
    {
        if (this.enemy != null)
        {
            Vector3 enemyPosition = new Vector3(this.enemy.transform.position.x, this.enemy.transform.position.y, this.enemy.transform.position.z);
            barrel.transform.LookAt(enemyPosition);

            if (ShouldKill())
            {
                nextKillTime = Time.time + .2f;
                KillEnemy();
            }          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            this.enemy = other.gameObject;
        }
    }

    private bool ShouldKill()
    {
        return Time.time > nextKillTime;
    }

    private void KillEnemy()
    {       
        Vector3 bulletPosition = new Vector3(balletSpawn.transform.position.x, balletSpawn.transform.position.y, balletSpawn.transform.position.z);
        GameObject insBullet = Instantiate(bullet, bulletPosition, transform.rotation);
        BulletController bulletController = insBullet.GetComponent<BulletController>();
        bulletController.currentEnemy = this.enemy;
        bulletController.forceDamage = this.forceDamage;
    }


}
