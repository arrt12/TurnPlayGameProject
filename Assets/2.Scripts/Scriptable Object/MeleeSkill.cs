using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSkill : SkillEffectBase
{
    [SerializeField] protected float damage;

    public override void Activate()
    {
    }
}

[CreateAssetMenu(fileName = "DelayedPowerStrikeSkill", menuName = "Skill Effects/MeleeSkill/DelayedPowerStrikeSkill")]
public class DelayedPowerStrikeSkill : MeleeSkill
{
    public override void Activate()
    {
        Debug.Log("강력한 근접 공격 스킬");
    }
}

[CreateAssetMenu(fileName = "UsurpApForDamageSkill", menuName = "Skill Effects/MeleeSkill/UsurpApForDamageSkill")]
public class UsurpApForDamageSkill : MeleeSkill
{
    public override void Activate() 
    {
        Debug.Log("AP 비례 근접 공격 스킬");
    }
}

[CreateAssetMenu(fileName = "HealthSacrificeStrikeSkill", menuName = "Skill Effects/MeleeSkill/HealthSacrificeStrikeSkill")]
public class HealthSacrificeStrikeSkill : MeleeSkill
{
    public override void Activate() 
    {
        Debug.Log("체력감소 비례 근접 공격 스킬");
    }
}


