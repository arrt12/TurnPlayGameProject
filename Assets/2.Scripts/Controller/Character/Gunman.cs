using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunman : JobBase
{
    private GunmanConfig config;

    public Gunman(GunmanConfig cfg) => config = cfg;

    public override void Act()
    {
        base.Action();
        controller.Animator.PlayShot();
        controller.GetComponent<PlayerController>().PlayerSpawnBullet();
    }

    public override void StartTurn()
    {
        base.StartTurn();
        controller.Animator.PlayTakeOut(true);
    }

    public override void EndTurn()
    {
        controller.Animator.PlayTakeOut(false);
    }
}
