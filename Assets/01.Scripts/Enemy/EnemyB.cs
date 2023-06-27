using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{

    public override void Init()
    {
        data.speed = 1f;
        data.hp = 5;
        fireDelayTime = 3f;

        base.Init();
    }

    void Start()
    {
        Init();
    }

}
