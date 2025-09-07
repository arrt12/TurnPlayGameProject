using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None,
    Skill_1,
    Skill_2
}
public class SkillSelectManager : MonoBehaviour
{
    [SerializeField] private SkillType CurrentSkill;
    private SkillManager currentSkillManager;

    public void SetSKkillByIndex(int index)
    {
        SkillType skill = (SkillType)index;
        SetSkill(skill);
    }

    public void SetSkill(SkillType skill) => CurrentSkill = skill;

    public void ResetSkill() => CurrentSkill =  SkillType.None;

    public void ActivateSkill()
    {
        GetCurrentSkillManager();
        switch (CurrentSkill)
        {
            case SkillType.Skill_1:
                ExecuteSkill1();
                break;
            case SkillType.Skill_2:
                ExecuteSkill2();
                break;
        }
    }

    public void ExecuteSkill1() => currentSkillManager.UseSkill(0);

    public void ExecuteSkill2() => currentSkillManager.UseSkill(1);

    private void GetCurrentSkillManager() => currentSkillManager = TurnManager.Instance.CurrentController.GetComponent<SkillManager>();
}
