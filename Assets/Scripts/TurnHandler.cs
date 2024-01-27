using System;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{

    public Action turnChange;

    public void EndTurn()
    {


        GlobalGameInstance.Instance.PlayerTurn = !GlobalGameInstance.Instance.PlayerTurn;

        turnChange?.Invoke();

        if (GlobalGameInstance.Instance.PlayerTurn == false)
        {
            GlobalGameInstance.Instance.EnemyObject.EnemyTurn();
        }
    }
    private void Awake()
    {
        GlobalGameInstance.Instance.TurnHandler = this;
    }

}
