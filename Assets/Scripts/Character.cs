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




    public void Initzialize()
    {
        _hp = _maxHp;
        _laughter = _maxLaughter;
    }

    public void TakeDamage(int damage)
    {
        _hp = _hp - damage;
        UpdateHpBar();
    }

    public void LaughterDamage(int damage)
    {
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
}
