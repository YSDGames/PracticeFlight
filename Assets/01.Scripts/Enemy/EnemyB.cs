using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB:Enemy
{

    public override void Init()
    {
        data.speed = 3;
        data.hp = 3;


        base.Init();
    }

    void Start()
    {


        Init();


    }

}
