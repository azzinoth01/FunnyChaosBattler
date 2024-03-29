using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private Character _player;



    private void Awake()
    {
        _player.Initzialize();
        GlobalGameInstance.Instance.Player = _player;
        GlobalGameInstance.Instance.PlayerObject = this;
    }



    [ContextMenu("Take DMG")]
    private void TestDamage()
    {
        _player.TakeDamage(1);
    }

    [ContextMenu("Take  Laughter DMG")]
    private void TestLaughterDmg()
    {
        _player.LaughterDamage(1);
    }
}
