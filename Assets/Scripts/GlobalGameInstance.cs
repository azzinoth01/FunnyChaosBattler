public class GlobalGameInstance
{


    private static GlobalGameInstance _instance;

    private Character _player;
    private Character _enemy;

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

    private GlobalGameInstance()
    {

    }
}
