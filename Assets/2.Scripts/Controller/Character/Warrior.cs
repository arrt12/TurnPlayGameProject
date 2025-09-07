using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : JobBase
{
    private WarriorConfig config;

    public Warrior(WarriorConfig cfg)
    {
        config = cfg;
    }
    public override void Act()
    {
        base.Action();
        controller.Animator.PlayRun(true);
        controller.GetComponent<MovementController>().RunEffectSetActive(true);
        controller.GetComponent<MovementController>().MoveStart(controller.Hit.transform);
    }

    public override void EndTurn()
    {
    }
}
