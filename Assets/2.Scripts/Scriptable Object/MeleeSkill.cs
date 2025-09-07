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
        Debug.Log("������ ���� ���� ��ų");
    }
}

[CreateAssetMenu(fileName = "UsurpApForDamageSkill", menuName = "Skill Effects/MeleeSkill/UsurpApForDamageSkill")]
public class UsurpApForDamageSkill : MeleeSkill
{
    public override void Activate() 
    {
        Debug.Log("AP ��� ���� ���� ��ų");
    }
}

[CreateAssetMenu(fileName = "HealthSacrificeStrikeSkill", menuName = "Skill Effects/MeleeSkill/HealthSacrificeStrikeSkill")]
public class HealthSacrificeStrikeSkill : MeleeSkill
{
    public override void Activate() 
    {
        Debug.Log("ü�°��� ��� ���� ���� ��ų");
    }
}


