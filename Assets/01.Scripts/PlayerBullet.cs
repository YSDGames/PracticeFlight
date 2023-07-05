using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float power = 1;



    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
