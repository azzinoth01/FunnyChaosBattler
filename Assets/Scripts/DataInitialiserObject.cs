using UnityEngine;

public class DataInitialiserObject : MonoBehaviour
{

    [SerializeField] private CardListScriptableObject _cardData;


    private void Awake()
    {
        foreach (Card card in _cardData.Cards)
        {
            GlobalGameInstance.Instance.CardData[card.Id] = card;
        }


    }


}
