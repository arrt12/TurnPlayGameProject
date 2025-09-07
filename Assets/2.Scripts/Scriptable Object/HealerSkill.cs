using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSkill : SkillEffectBase
{
    [SerializeField] protected float healAmount;

    public override void Activate()
    {
    }
}

[CreateAssetMenu(fileName = "HealthRestoreSkill", menuName = "Skill Effects/HealerSkill/HealthRestoreSkill")]
public class HealthRestoreSkill : HealerSkill
{
    public override void Activate() 
    {
        Debug.Log("힐 스킬");
    } 
}

[CreateAssetMenu(fileName = "ApRestoreSkill", menuName = "Skill Effects/HealerSkill/ApRestoreSkill")]
public class ApRestoreSkill : HealerSkill
{
    public override void Activate() 
    {
        Debug.Log("AP충천 스킬");
    }
}

[CreateAssetMenu(fileName = "AttackBuffSkill", menuName = "Skill Effects/HealerSkill/AttackBuffSkill")]
public class AttackBuffSkill : HealerSkill
{
    public override void Activate() 
    {
        Debug.Log("공격력 증가 스킬");
    }
}



