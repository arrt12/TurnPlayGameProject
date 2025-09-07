using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RayCastType
{
    None,
    ScreenCenterClick,
    MousePositionClick
}

public class RaycastManager : Singleton<RaycastManager>
{
    [Header("0:none, 1:MousePositionClick, 2:ObjectElementClick")]
    [SerializeField] public RayCastType CurrentrayCastType;

    public void SetActionByIndex(int index)
    {
        RayCastType raycastType = (RayCastType)index;
        CurrentrayCastType = raycastType;
    }

    public Ray GetRayByType()
    {
        Ray ray = default;
        switch (CurrentrayCastType)
        {
            case RayCastType.ScreenCenterClick:
                ray = GetRayFromScreenCenter();
                break;
            case RayCastType.MousePositionClick:
                ray = GetRayFromMousePosition();
                break;
            case RayCastType.None:
            default:
                break;
        }
        return ray;
    }

    private Ray GetRayFromScreenCenter()
    {
        Vector3 center = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        return ScreenPointToRay(center);
    }

    private Ray GetRayFromMousePosition()
    {
        Vector3 pos = Input.mousePosition;
        return ScreenPointToRay(pos);
    }

    private static Ray ScreenPointToRay(Vector3 screenCenter)
    {
        return Camera.main.ScreenPointToRay(screenCenter);
    }
}
