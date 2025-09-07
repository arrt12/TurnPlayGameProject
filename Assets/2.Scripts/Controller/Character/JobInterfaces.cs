using UnityEngine;

public interface IJobUnit : IUnitBehavior, IDamageable, ISkillble, IEndTurn, IStartTurn, ICameraRayProvider, ISetPlayerController { }

// 기능 인터페이스 
public interface IUnitBehavior { void Act(); }
public interface IDamageable { void GetDamage(); }
public interface IStartTurn { void StartTurn(); }
public interface IEndTurn { void EndTurn(); };
public interface ISkillble { void Skill(); }
public interface ICameraRayProvider { Ray GetRayFromScreenCenter(); };
public interface ISetPlayerController { void SetPlayerController(PlayerController controller); };
