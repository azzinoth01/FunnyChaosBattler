using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] private Character _player;



    private void Start()
    {
        _player.Initzialize();
        GlobalGameInstance.Instance.Player = _player;
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
