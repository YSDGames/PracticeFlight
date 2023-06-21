using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    [SerializeField] EnemyBulletA bullet;
    [SerializeField] Transform parent;
    [SerializeField] Transform bulletParent;

    public float fireDelayTime;
    float fireTimer;

    void Start()
    {
        bulletParent = GameObject.Find("PlayerBullet").transform;
    }


    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 1f);

        //Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        
    }

    

    void Shoot()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTime)
        {

            EnemyBulletA b = Instantiate(bullet, parent);
            b.name = "eBullet";
            b.transform.SetParent(bulletParent);

            fireTimer = 0;

        }
    }
}
