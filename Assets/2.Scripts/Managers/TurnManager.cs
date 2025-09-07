using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : Singleton<TurnManager>
{
    private readonly Queue<Controller> turns = new();

    public Controller[] characters;

    public Controller CurrentController;
    private Dictionary<CombatPosition, List<Controller>> playingControllers = new();

    [SerializeField] private float nextTurnTime = 1f;

    private void Start()
    {
        foreach (Controller c in characters)
            turns.Enqueue(c);

        SetControllers();

        Turn();
    }

    public void SetControllers()//키를 구분에서 값을 저장
    {
        playingControllers.Clear();
        foreach (Controller c in characters)
        {
            if (!playingControllers.ContainsKey(c.CombatPosition))
                playingControllers.Add(c.CombatPosition, new());

            playingControllers[c.CombatPosition].Add(c);
        }
    }

    public List<Controller> GetControllers(CombatPosition combatPosition)
    {
        return playingControllers[combatPosition];
    }

    private void Turn()
    {
        Controller controller = turns.Dequeue();
        CurrentController = controller;

        CurrentController.StartTurn();
        turns.Enqueue(controller);
    }

    public void EndTurn() => Invoke(nameof(Turn), nextTurnTime);   
}
