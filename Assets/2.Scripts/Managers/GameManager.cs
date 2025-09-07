using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isActionSelection = false;
    public PlayerInputHandler PlayerInputHandler;

    public void SetActionSelection(bool isActionSelection)
    {
        this.isActionSelection = isActionSelection;
    }

    public bool IsActionSelection()
    {
        return isActionSelection;
    }
}
