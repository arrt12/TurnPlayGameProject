using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealarActionType
{
    None,
    Attack,
    Heal
}

public class HealActionExecutor : MonoBehaviour
{
    private HealarActionType actionType;
    private PlayerController controller;
    private HealerConfig healerConfig;

    [SerializeField] private Transform healEffectSpawnPos;

    [SerializeField] private GameObject healEffect;
    [SerializeField] private GameObject healBoomEffect;

    [SerializeField] private GameObject healPopUpEffect;
    [SerializeField] private Vector3 healPopUpEffectAngle;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        healerConfig = (HealerConfig)controller.JobConfig;
    }

    public void SetHealarActionType(HealarActionType actionType) => this.actionType = actionType;

    public void ChangeToAttack() => ChangeTag(healerConfig.UniversalRayCastTagName);

    public void ChangeToHeal() => ChangeTag(healerConfig.HealRayCastTagName);

    public void SpawnHealEffect(Transform pos) => controller.SpawnGameEffect(healEffect, pos.position, Quaternion.identity);

    public void SpawnHealBoomEffect(Controller controller) => controller.SpawnGameEffect(healBoomEffect, controller.transform.position, Quaternion.identity);

    public void SpawnHealPopUpEffect(Transform pos) => controller.SpawnGameEffect(healPopUpEffect, pos.position, Quaternion.Euler(healPopUpEffectAngle));

    private void ChangeTag(string tag) => controller.RaycastHitTagName = tag;
}
