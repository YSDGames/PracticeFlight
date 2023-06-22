using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public override void Init()
    {
        data.speed = 3;
        data.hp = 10;


        base.Init();
    }

    void Start()
    {


        Init();
        

    }

    public override void test()
    {
        Debug.Log("000-0");
    }

    



}
