using UnityEngine;
using System.Collections.Generic;

public class AnimationOverrideManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorOverrideController defaultOverrideController;

    private AnimatorOverrideController currentOverrideController;

    // �⺻ �������̵� ��Ʈ�ѷ� ����
    private void Awake() => SetOverrideController(defaultOverrideController);

    private void SetOverrideController(AnimatorOverrideController newOverrideController)
    {
        // ���ο� �������̵� ��Ʈ�ѷ��� ����
        currentOverrideController = newOverrideController;
        ApplyOverrides();
    }

    // ĳ���ͺ� �������̵� ��Ʈ�ѷ��� ����
    public void SetCharacterAnimation(AnimatorOverrideController newCharacterOverrideController) => SetOverrideController(newCharacterOverrideController);

    private void ApplyOverrides()
    {
        if (currentOverrideController == null)
            return;

        var aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>(aoc.overridesCount);
        currentOverrideController.GetOverrides(overrides);

        foreach (var kv in overrides)
        {
            aoc[kv.Key.name] = kv.Value;
        }

        animator.runtimeAnimatorController = aoc;
    }
}
