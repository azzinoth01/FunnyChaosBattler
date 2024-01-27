using System.Collections.Generic;

public class GlobalGameInstance
{


    private static GlobalGameInstance _instance;

    private Character _player;
    private Character _enemy;
    private Dictionary<int, Card> _cardData;


    public static GlobalGameInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalGameInstance();
            }
            return _instance;
        }

    }

    public Character Player
    {
        get
        {
            return _player;
        }

        set
        {
            _player = value;
        }
    }

    public Character Enemy
    {
        get
        {
            return _enemy;
        }

        set
        {
            _enemy = value;
        }
    }

    public Dictionary<int, Card> CardData
    {
        get
        {
            return _cardData;
        }
    }

    private GlobalGameInstance()
    {
        _cardData = new Dictionary<int, Card>();
    }
}
