using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBasicAttackEventController : MonoBehaviour
{
    private Vector3 resetPos;

    [SerializeField] private MovementController movementController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject attackClashEndEffect;
    [SerializeField] private float spawnYOffset;

    [Header("ResetPosSetting")]
    [SerializeField] private float startWaitTime;
    [SerializeField] private float waitAnimationWaitTime;
    [SerializeField] private float teleportWaitTime;
    [SerializeField] private GameObject teleportEffect;

    private WaitForSeconds waitStart, waitAnimation, waitTeleport;

    private void Awake()
    {
        waitStart = new WaitForSeconds(startWaitTime);
        waitAnimation = new WaitForSeconds(waitAnimationWaitTime);
        waitTeleport = new WaitForSeconds(teleportWaitTime);
    }

    private void Start()
    {
        movementController.Arrivalsubscribe(() => EndAction());
        resetPos = playerController.transform.position;
    }

    private void EndAction()
    {
        movementController.RunEffectSetActive(false);
        ActionEndAnimation();
        playerController.SpawnGameEffect(attackClashEndEffect, SpawnPos(spawnYOffset), Quaternion.identity);
        StartCoroutine(nameof(PlayerResetPos));
    }

    private Vector3 SpawnPos(float spawnYOffset)
    {
        var t = playerController.transform;
        return new Vector3(t.position.x, t.position.y + spawnYOffset, t.position.z);
    }

    private void ActionEndAnimation()
    {
        playerController.Animator.PlayHit();
        playerController.Animator.PlayRun(false);
    }

    private IEnumerator PlayerResetPos()
    {
        yield return waitStart;
        TriggerTeleportEffect();
        movementController.IsMove = false;

        yield return waitAnimation;
        PlaySpawnAnimation();

        yield return waitTeleport;
        ResetPlayerToStart();
    }

    private void TriggerTeleportEffect() => playerController.SpawnGameEffect(teleportEffect, SpawnPos(-0.1f), Quaternion.identity);

    private void PlaySpawnAnimation() => playerController.Animator.PlaySpawn();

    private void ResetPlayerToStart()
    {
        playerController.transform.position = resetPos;
        movementController.IsArrivalTriggered = false;
    }
}
