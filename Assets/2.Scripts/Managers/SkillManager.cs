using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<SkillEffectBase> skills;

    public void UseSkill(int index) => skills[index].Activate();

    public void AddSkill(SkillEffectBase skill, int index)
    {
        if (skills.Count > 2) return;

        skills[index] = skill;
    }

    public void AllRemoveSkill() 
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i] = null;
        }
    }
}
