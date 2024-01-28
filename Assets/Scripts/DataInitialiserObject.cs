using UnityEngine;

public class DataInitialiserObject : MonoBehaviour
{

    [SerializeField] private CardListScriptableObject _cardData;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _playerTextBubble;
    [SerializeField] private GameObject _enemyTextBubble;

    private void Awake()
    {

        GlobalGameInstance.Instance.CardData.Clear();
        foreach (Card card in _cardData.Cards)
        {
            GlobalGameInstance.Instance.CardData[card.Id] = card;
        }

        GlobalGameInstance.Instance.WinScreen = _winScreen;
        GlobalGameInstance.Instance.LoseScreen = _loseScreen;
        GlobalGameInstance.Instance.PlayerTextBubble = _playerTextBubble;
        GlobalGameInstance.Instance.EnemyTextBubble = _enemyTextBubble;
    }


}
