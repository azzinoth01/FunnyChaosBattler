using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private Character _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _enemy.Initzialize();
        GlobalGameInstance.Instance.Enemy = _enemy;
    }




    [ContextMenu("Take DMG")]
    private void TestDamage()
    {
        _enemy.TakeDamage(1);
    }


    [ContextMenu("Take  Laughter DMG")]
    private void TestLaughterDmg()
    {
        _enemy.LaughterDamage(1);
    }
}
