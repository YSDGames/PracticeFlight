using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public override void Init()
    {
        data.speed = 1;
        data.hp = 5;
        fireDelayTime = 2f;

        base.Init();
    }
    void Start()
    {
        Init();
    }
}
