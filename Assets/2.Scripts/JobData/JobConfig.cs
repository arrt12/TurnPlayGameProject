using UnityEngine;

public abstract class JobConfig : ScriptableObject
{
    public float AttackDamage;
    public string UniversalRayCastTagName;
}

[CreateAssetMenu(fileName = "GunmanConfig", menuName = "Jobs/Gunman Config", order = int.MaxValue)]
public class GunmanConfig : JobConfig { }

[CreateAssetMenu(fileName = "WarriorConfig", menuName = "Jobs/Warrior Config", order = int.MaxValue)]
public class WarriorConfig : JobConfig 
{
}

[CreateAssetMenu(fileName = "HealerConfig", menuName = "Jobs/Healer Config", order = int.MaxValue)]
public class HealerConfig : JobConfig {
    public string HealRayCastTagName;
}

