using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDManager : Singleton<PlayerHUDManager>
{
    [SerializeField] private GameObject actionSelection;
    [SerializeField] private GameObject mousePoint;

    private void Update()
    {
        SetActionSelectionActive();
    }

    public void ToggleMousePoint(bool isMousePointVisible) => mousePoint.SetActive(isMousePointVisible);

    private void SetActionSelectionActive()
    {
        bool isSetActive = GameManager.Instance.IsActionSelection();
        actionSelection.SetActive(isSetActive);
    }
}
