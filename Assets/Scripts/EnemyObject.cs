using System.Collections;

using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private Character _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _enemy.Initzialize();
        GlobalGameInstance.Instance.Enemy = _enemy;
        GlobalGameInstance.Instance.EnemyObject = this;
    }


    public void EnemyTurn()
    {
        StartCoroutine(StartEnemyTurn());
    }

    private IEnumerator StartEnemyTurn()
    {
        yield return new WaitForSeconds(1);

        _enemy.EnemyTurnDmg();
        yield return new WaitForSeconds(1);

        GlobalGameInstance.Instance.TurnHandler.EndTurn();

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
