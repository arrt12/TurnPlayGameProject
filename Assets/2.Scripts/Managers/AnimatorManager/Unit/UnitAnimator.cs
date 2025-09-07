using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayRun(bool isRun) => animator.SetBool("isRun", isRun);
    public void PlayAttack() => animator.SetTrigger("Attack");
    public void PlayDie() => animator.SetTrigger("Die");
    public void PlayTakeOut(bool isTakeOut) => animator.SetBool("isTakeOut", isTakeOut);
    public void PlayShot() => animator.SetTrigger("Shot");
    public void PlayAction() => animator.SetTrigger("Action");
    public void PlayHit() => animator.SetTrigger("Hit");
    public void PlaySpawn() => animator.SetTrigger("Spawn");
}
