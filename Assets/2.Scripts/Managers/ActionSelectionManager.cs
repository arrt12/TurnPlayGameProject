using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionSelect
{
    None,
    Defense,
    ExecuteRTCombatAction,
    BasicAciton,
    Skill
}

public class ActionSelectionManager : Singleton<ActionSelectionManager>
{
    public ActionSelect CurrentAction { get; private set; } = ActionSelect.None;
    public PlayerController Player;

    public void SetActionByIndex(int index)
    {
        ActionSelect action = (ActionSelect)index;
        SetAction(action);
    }

    public void SetPlayer(PlayerController player) => this.Player = player;

    public void SetAction(ActionSelect action) => CurrentAction = action;

    public void ResetAction() => CurrentAction = ActionSelect.None;

    public void EndAction() => TurnManager.Instance.EndTurn();

    public void PerformSelectedAction()
    {
        switch (CurrentAction)
        {
            case ActionSelect.Defense:
                Defense();
                break;
            case ActionSelect.ExecuteRTCombatAction:
                ExecuteRTCombatAction();
                break;
            case ActionSelect.BasicAciton:
                BasicAciton();
                break;
            case ActionSelect.Skill:
                Skill();
                break;
        }
    }

    private void Defense()
    {
        print("Defense");
        Player.SetActionMode(false);
    }

    private void ExecuteRTCombatAction()
    {
        ActionSetting(Player.RTCActionCameraPosition, true, CursorLockMode.Locked, false, true);
        ActionMode();
    }

    private void BasicAciton()
    {
        ActionSetting(Player.ActionCameraPosition, false, CursorLockMode.None, true, false);
        ActionMode();
    }

    private void Skill()
    {
        Player.SetActionMode(false);
    }

    private void ActionMode()
    {
        Player.SetActionMode(true);
        Player.InActionMode();
    }

    private void ActionSetting(Transform cameraPosition, bool isIncombatCameraPosition, CursorLockMode cursorLockMode, bool visible, bool isMousePointVisible)
    {
        PlayerCameraManager.Instance.SetTarget(cameraPosition);
        PlayerCameraManager.Instance.SetCombatCameraState(isIncombatCameraPosition);
        Player.ToggleCursorLock(cursorLockMode, visible);
        PlayerHUDManager.Instance.ToggleMousePoint(isMousePointVisible);
    }
}
