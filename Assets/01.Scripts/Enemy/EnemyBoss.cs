using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{ 
    public override void Init()
    {
        data.speed = 0.2f;
        data.hp = 20;
        fireDelayTime = 1f;

        base.Init();
    }
    void Start()
    {
        Init();
    }
}
