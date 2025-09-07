using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    protected override void Awake()
    {
        print("¹Ì±¸Çö");
    }
    public override void StartTurn()
    {
        base.StartTurn();
        Action();
    }

    public override void Action()
    {
        base.Action();
    }
}
