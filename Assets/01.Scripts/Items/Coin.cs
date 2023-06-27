using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    void Start()
    {
        speed = 1f;
        base.Init();
    }
}
