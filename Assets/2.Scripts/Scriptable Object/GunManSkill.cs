using UnityEngine;

public class GunManSkill : SkillEffectBase
{
    [SerializeField] protected float damage;
    [SerializeField] GameObject firePrefab;

    public override void Activate() { }
}

// ���� ����Ŭ���� 1: ȭ�� ȿ��
[CreateAssetMenu(fileName = "RangedStrike", menuName = "Skill Effects/GunManSkill/RangedStrike")]
public class RangedStrike : GunManSkill
{
    //ũ�� ������ ����
    public override void Activate()
    {
        Debug.Log("������ ���� ��ų");
    }
}

[CreateAssetMenu(fileName = "MultiShot", menuName = "Skill Effects/GunManSkill/MultiShot")]
public class MultiShot : GunManSkill
{
    //3�������� ������ ��Ƽ��
    public override void Activate()
    {
        Debug.Log("��Ƽ�� ��ų");
    }
}

[CreateAssetMenu(fileName = "RushEffect", menuName = "Skill Effects/GunManSkill/RushEffect")]
public class RushEffect : GunManSkill
{
    //�������� ���Ÿ� ����
    public override void Activate()
    {
        Debug.Log("���Ӽ� ��ų");
    }
}



