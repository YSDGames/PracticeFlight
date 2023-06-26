using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public override void Init()
    {
        data.speed = 3;
        data.hp = 5;
        fireDelayTime = 1;

        base.Init();
    }

    void Start()
    {


        Init();
        

    }
       

}
