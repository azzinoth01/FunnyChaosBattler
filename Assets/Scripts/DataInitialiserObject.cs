using UnityEngine;

public class DataInitialiserObject : MonoBehaviour
{

    [SerializeField] private CardListScriptableObject _cardData;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    private void Awake()
    {
        foreach (Card card in _cardData.Cards)
        {
            GlobalGameInstance.Instance.CardData[card.Id] = card;
        }

        GlobalGameInstance.Instance.WinScreen = _winScreen;
        GlobalGameInstance.Instance.LoseScreen = _loseScreen;
    }


}
