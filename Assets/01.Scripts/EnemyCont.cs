using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    [SerializeField] EnemyA enemy;
    [SerializeField] Transform parent;

    [SerializeField] BoxCollider2D spawnBox;
    public Transform enemyBullet;

    public static EnemyCont instance;
    private void Start()
    {
        //InvokeRepeating("RandomPosition", 1f , 1f);
        //StartCoroutine(SpawnEnemy());
        StartCoroutine("SpawnEnemy");


        instance = this;
    }

    void Update()
    {
        
    }

    void RandomPosition()
    {
        Vector3 pos = spawnBox.transform.position;

        float sizeX = spawnBox.bounds.size.x;
        float sizeY = spawnBox.bounds.size.y;

        sizeX = Random.Range((sizeX / 2) * -1, sizeX / 2);
        sizeY = Random.Range((sizeY / 2) * -1, sizeY / 2);

        Vector3 randomPos = new Vector3(sizeX, sizeY, 0f);

        Vector3 randPos = pos + randomPos;
        Enemy e = Instantiate(enemy, randPos, Quaternion.identity, parent);

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
             
            RandomPosition();
        }
    }
    
}
