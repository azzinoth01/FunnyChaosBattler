using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private List<AudioClip> _dmgTakenSound;
    [SerializeField] private List<AudioClip> _doubleDmgTakenSound;
    [SerializeField] private List<AudioClip> _halfDmgTakenSound;
    [SerializeField] private List<AudioClip> _laughterBreak;




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



        _audioSource.clip = _dmgTakenSound[Random.Range(0, _dmgTakenSound.Count)];

        UpdateHpBar();
    }

    public void LaughterDamage(int damage, TypeEnum type = TypeEnum.None)
    {

        float multiplier = _type.GetTypeMultiplier(type);


        damage = (int)(damage * multiplier);
        _laughter = _laughter - damage;

        if (multiplier == 2)
        {
            _enemyReaction = -1;
            if (_laughter > 0)
            {
                _audioSource.clip = _doubleDmgTakenSound[Random.Range(0, _doubleDmgTakenSound.Count)];
            }
        }
        else if (multiplier == 1)
        {
            _enemyReaction = 0;
            if (_laughter > 0)
            {
                _audioSource.clip = _dmgTakenSound[Random.Range(0, _dmgTakenSound.Count)];
            }
        }
        else
        {
            _enemyReaction = 1;
            if (_laughter > 0)
            {
                _audioSource.clip = _halfDmgTakenSound[Random.Range(0, _halfDmgTakenSound.Count)];
            }
        }


        if (_laughter <= 0)
        {

            _audioSource.clip = _laughterBreak[Random.Range(0, _laughterBreak.Count)];

        }

        _audioSource.Play();

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


        int damage;
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
