using UnityEngine;

public class GunManSkill : SkillEffectBase
{
    [SerializeField] protected float damage;
    [SerializeField] GameObject firePrefab;

    public override void Activate() { }
}

// 예시 서브클래스 1: 화염 효과
[CreateAssetMenu(fileName = "RangedStrike", menuName = "Skill Effects/GunManSkill/RangedStrike")]
public class RangedStrike : GunManSkill
{
    //크고 강력한 공격
    public override void Activate()
    {
        Debug.Log("강력한 공격 스킬");
    }
}

[CreateAssetMenu(fileName = "MultiShot", menuName = "Skill Effects/GunManSkill/MultiShot")]
public class MultiShot : GunManSkill
{
    //3방향으로 나가는 멀티샷
    public override void Activate()
    {
        Debug.Log("멀티샷 스킬");
    }
}

[CreateAssetMenu(fileName = "RushEffect", menuName = "Skill Effects/GunManSkill/RushEffect")]
public class RushEffect : GunManSkill
{
    //연속으로 원거리 공격
    public override void Activate()
    {
        Debug.Log("연속샷 스킬");
    }
}



