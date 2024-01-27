using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardListData", menuName = "ScriptableObjects/CardList", order = 1)]
public class CardListScriptableObject : ScriptableObject
{

    [SerializeField] private List<Card> _cards;

    public List<Card> Cards
    {
        get
        {
            return _cards;
        }

        set
        {
            _cards = value;
        }
    }
}
