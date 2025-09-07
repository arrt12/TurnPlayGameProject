using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JobBase : IJobUnit
{
    protected PlayerController controller;

    public void SetPlayerController(PlayerController controller) => this.controller = controller;

    public abstract void Act();
    
    public virtual void StartTurn()
    {
        //PlayerCameraManager.Instance.SetCombatCameraState(true);
        //controller.ToggleCursorLock(CursorLockMode.Locked, false);
        //PlayerHUDManager.Instance.ToggleMousePoint(true);
    }

    public virtual void Skill() { }

    public abstract void EndTurn();

    public virtual void GetDamage(){}

    public virtual Ray GetRayFromScreenCenter()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter); 
        return ray;
    }

    protected virtual void Action() 
    {
        Debug.Log("Test2");
        controller.Action();
    }

}
