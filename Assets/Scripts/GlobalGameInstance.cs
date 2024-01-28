using System.Collections.Generic;
using UnityEngine;

public class GlobalGameInstance
{


    private static GlobalGameInstance _instance;

    private Character _player;
    private Character _enemy;
    private EnemyObject _enemyObject;
    private Dictionary<int, Card> _cardData;
    private bool _playerTurn;
    private TurnHandler _turnHandler;
    private GameObject _loseScreen;
    private GameObject _winScreen;
    private GameObject _playerTextBubble;
    private GameObject _enemyTextBubble;
    private PlayerObject _playerObject;

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

    public bool PlayerTurn
    {
        get
        {
            return _playerTurn;
        }

        set
        {
            _playerTurn = value;
        }
    }

    public EnemyObject EnemyObject
    {
        get
        {
            return _enemyObject;
        }

        set
        {
            _enemyObject = value;
        }
    }

    public TurnHandler TurnHandler
    {
        get
        {
            return _turnHandler;
        }

        set
        {
            _turnHandler = value;
        }
    }

    public GameObject LoseScreen
    {
        get
        {
            return _loseScreen;
        }

        set
        {
            _loseScreen = value;
        }
    }

    public GameObject WinScreen
    {
        get
        {
            return _winScreen;
        }

        set
        {
            _winScreen = value;
        }
    }

    public GameObject PlayerTextBubble
    {
        get
        {
            return _playerTextBubble;
        }

        set
        {
            _playerTextBubble = value;
        }
    }

    public GameObject EnemyTextBubble
    {
        get
        {
            return _enemyTextBubble;
        }

        set
        {
            _enemyTextBubble = value;
        }
    }

    public PlayerObject PlayerObject
    {
        get
        {
            return _playerObject;
        }

        set
        {
            _playerObject = value;
        }
    }

    private GlobalGameInstance()
    {
        _cardData = new Dictionary<int, Card>();
        _playerTurn = true;
    }
}
