using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private Character _enemy;


    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _eneymAttackSound;
    [SerializeField] private List<AudioClip> _enemyImpactSound;

    // Start is called before the first frame update
    void Awake()
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
        _audioSource.clip = _eneymAttackSound[Random.Range(0, _eneymAttackSound.Count)];
        _audioSource.Play();

        yield return new WaitForSeconds(_audioSource.clip.length);

        _audioSource.clip = _enemyImpactSound[Random.Range(0, _enemyImpactSound.Count)];
        _audioSource.Play();

        _enemy.EnemyTurnDmg();
        yield return new WaitForSeconds(0.3f);

        if (GlobalGameInstance.Instance.Player.Hp <= 0)
        {
            GlobalGameInstance.Instance.LoseScreen.SetActive(true);
        }
        else
        {
            GlobalGameInstance.Instance.TurnHandler.EndTurn();
        }



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
