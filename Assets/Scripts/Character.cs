using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Character
{
    [SerializeField] private int _maxHp;
    [SerializeField] private int _hp;
    [SerializeField] private Image _hpBar;
    [SerializeField] private int _laughter;
    [SerializeField] private int _maxLaughter;
    [SerializeField] private Image _laughterBar;
    [SerializeField] private TypeEnum _type;
    [SerializeField] private int _enemyDmg;

    private int _enemyReaction;

    public int Hp
    {
        get
        {
            return _hp;
        }


    }

    public int Laughter
    {
        get
        {
            return _laughter;
        }


    }

    public void Initzialize()
    {
        _hp = _maxHp;
        _laughter = _maxLaughter;
    }

    public void TakeDamage(int damage, TypeEnum type = TypeEnum.None)
    {

        if (_laughter > 0)
        {
            return;
        }

        // damage = (int)(damage * _type.GetTypeMultiplier(type));
        _hp = _hp - damage;
        UpdateHpBar();
    }

    public void LaughterDamage(int damage, TypeEnum type = TypeEnum.None)
    {

        float multiplier = _type.GetTypeMultiplier(type);
        if (multiplier == 2)
        {
            _enemyReaction = -1;
        }
        else if (multiplier == 1)
        {
            _enemyReaction = 0;
        }
        else
        {
            _enemyReaction = 1;
        }

        damage = (int)(damage * multiplier);
        _laughter = _laughter - damage;
        UpdateLaughterBar();
    }


    private void UpdateHpBar()
    {


        _hpBar.fillAmount = (float)_hp / _maxHp;
    }

    private void UpdateLaughterBar()
    {
        _laughterBar.fillAmount = (float)_laughter / _maxLaughter;
    }



    public void EnemyTurnDmg()
    {
        int damage = 0;
        if (_enemyReaction == -1)
        {
            damage = 0;
        }
        else if (_enemyReaction == 0)
        {
            damage = 1;
        }
        else
        {
            damage = 2;
        }

        damage = _enemyDmg * damage;

        if (GlobalGameInstance.Instance.Player.Laughter > 0)
        {
            GlobalGameInstance.Instance.Player.LaughterDamage(damage);
        }
        else
        {
            GlobalGameInstance.Instance.Player.TakeDamage(damage);
        }
    }
}
