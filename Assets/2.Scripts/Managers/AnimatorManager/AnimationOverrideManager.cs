using UnityEngine;
using System.Collections.Generic;

public class AnimationOverrideManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorOverrideController defaultOverrideController;

    private AnimatorOverrideController currentOverrideController;

    // 기본 오버라이드 컨트롤러 설정
    private void Awake() => SetOverrideController(defaultOverrideController);

    private void SetOverrideController(AnimatorOverrideController newOverrideController)
    {
        // 새로운 오버라이드 컨트롤러를 설정
        currentOverrideController = newOverrideController;
        ApplyOverrides();
    }

    // 캐릭터별 오버라이드 컨트롤러를 설정
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
