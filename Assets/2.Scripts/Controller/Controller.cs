using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum CombatPosition
{
    A,
    B
}

// Unit ������
public enum JobType
{
    none,
    Gunman,
    Warrior,
    Healer
}

public class Controller : MonoBehaviour
{
    // �� �����ϴ� ����
    public CombatPosition CombatPosition;

    public State State = new();
    [SerializeField] protected bool isTurn; //[SerializeField] �׽�Ʈ ������ ����

    [SerializeField] protected Transform turnStartCameraPosition;
    [SerializeField] public UnitAnimator Animator;

    [SerializeField] private AnimationOverrideManager animationOverrideManager;
    [SerializeField] private AnimatorOverrideController OverrideController;
    public GameObject AttackBoomEffectObject;
    public GameObject AttackEffectObject;
    public Transform AttackEffectObjectPos;
    private GameObject effect;

    protected virtual void Awake() => animationOverrideManager.SetCharacterAnimation(OverrideController);

    public virtual void Action()
    {
        FinishTurn();
    }

    public virtual void GetDamage()
    {
    }

    public virtual void StartTurn()
    {
        isTurn = true;
        PlayerCameraManager.Instance.SetTarget(turnStartCameraPosition);
    }

    public virtual void EndTurn()
    {
        isTurn = false;
    }

    private void FinishTurn()
    {
        EndTurn();
        print("����");
        TurnManager.Instance.EndTurn();
    }

    public void SpawnGameEffect(GameObject spawnObject, Vector3 spawnPos, Quaternion rotation, Transform parent = null)
    {
        if (spawnObject == null) return;

        if (parent != null)
        {
            effect = Instantiate(spawnObject, spawnPos, rotation, parent);
            effect.transform.localPosition = spawnPos;
        }
        else
            Instantiate(spawnObject, spawnPos, rotation);
    }

    public void DestroyEffect()
    {
        if (effect == null)
            return;
        Destroy(effect);
        effect = null;
    }
}
