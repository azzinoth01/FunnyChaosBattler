using System;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{

    public Action turnChange;

    [SerializeField] private TMPro.TextMeshProUGUI _turnChangeText;

    [SerializeField] private Sprite _idleAnimation;

    public void EndTurn()
    {


        GlobalGameInstance.Instance.PlayerTurn = !GlobalGameInstance.Instance.PlayerTurn;

        GlobalGameInstance.Instance.PlayerObject.GetComponent<SpriteRenderer>().sprite = _idleAnimation;
        GlobalGameInstance.Instance.EnemyObject.GetComponent<SpriteRenderer>().sprite = _idleAnimation;

        if (GlobalGameInstance.Instance.PlayerTurn == false)
        {

            _turnChangeText.text = "Enemy turn";

            GlobalGameInstance.Instance.EnemyObject.EnemyTurn();
        }
        else
        {
            _turnChangeText.text = "Player turn";
            turnChange?.Invoke();
        }
    }
    private void Awake()
    {
        GlobalGameInstance.Instance.TurnHandler = this;
    }

    public void InvokeTurnChangeEvent()
    {
        turnChange?.Invoke();
    }

}
