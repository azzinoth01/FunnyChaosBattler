using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    [SerializeField] private int _id;
    [SerializeField] private List<CardEffect> _cardEffects;

    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public List<CardEffect> CardEffects
    {
        get
        {
            return _cardEffects;
        }

        set
        {
            _cardEffects = value;
        }
    }
}

