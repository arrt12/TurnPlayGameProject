using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : JobBase
{
    private HealerConfig config;
    private bool inCombat;
    private HealActionExecutor healExecutor;

    public Healer(HealerConfig cfg)
    {
        config = cfg;
    }

    public override void Act()
    {
        base.Action();
        controller.Animator.PlayAction();
        HandleAction();
    }

    private void HandleAction()
    {
        if (inCombat)
            Attack();
        else
            Heal();
    }

    public override void StartTurn()
    {
        base.StartTurn();
        ChangeTag();
    }

    private void ChangeTag()
    {
        inCombat = PlayerCameraManager.Instance.GetIsIncombatCameraPosition();
        ApplyTag(inCombat);
    }

    private void ApplyTag(bool inCombat)
    {
        healExecutor = controller.GetComponent<HealActionExecutor>();
        CheckAction(inCombat, healExecutor);
    }

    private void CheckAction(bool inCombat, HealActionExecutor executor)
    {
        if (inCombat)
            executor.ChangeToAttack();
        else
            executor.ChangeToHeal();
    }

    private void Attack()
    {
        controller.GetComponent<PlayerController>().PlayerSpawnBullet();
    }

    private void Heal()
    {
        SpawnHealEffects();
    }

    private void SpawnHealEffects()
    {
        PlayerController raycastHitUnit = controller.Hit.collider.GetComponent<PlayerController>();

        healExecutor.SpawnHealEffect(raycastHitUnit.MagicCircleSpawnPos);
        healExecutor.SpawnHealBoomEffect(controller);
        healExecutor.SpawnHealPopUpEffect(raycastHitUnit.transform);
    }

    public override void EndTurn()
    {
    }
}
