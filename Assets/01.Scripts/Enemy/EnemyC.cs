using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : Enemy
{

    public override void Init()
    {
        data.speed = 1f;
        data.hp = 10;
        fireDelayTime = 1.5f;

        base.Init();
    }

    void Start()
    {
        Init();
    }

}
