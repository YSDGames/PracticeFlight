using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletA : MonoBehaviour
{
    [HideInInspector] public float speed=3f;

    private void Awake()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
