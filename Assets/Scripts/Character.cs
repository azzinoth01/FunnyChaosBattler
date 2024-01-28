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


    [SerializeField] private List<string> _dmgTakenTexts;
    [SerializeField] private List<string> _doubleDmgTakenTexts;
    [SerializeField] private List<string> _halfDmgTakenTexts;
    [SerializeField] private List<string> _laughterTexts;

    [SerializeField] private Sprite _hitSprite;
    [SerializeField] private Sprite _laughterSprite;

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
        _audioSource.gameObject.GetComponent<SpriteRenderer>().sprite = _hitSprite;
        UpdateHpBar();
    }

    public void LaughterDamage(int damage, TypeEnum type = TypeEnum.None)
    {
        GameObject gameObject = _audioSource.gameObject;
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

        gameObject.GetComponent<SpriteRenderer>().sprite = _hitSprite;
        if (_laughter <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _laughterSprite;
            _audioSource.clip = _laughterBreak[Random.Range(0, _laughterBreak.Count)];

            if (this == GlobalGameInstance.Instance.Enemy)
            {
                GlobalGameInstance.Instance.EnemyObject.EnemyComebackText(_laughterTexts[Random.Range(0, _laughterTexts.Count)]);
            }



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

        EnemyObject enemy = GlobalGameInstance.Instance.EnemyObject;
        int damage;
        if (_enemyReaction == -1)
        {
            damage = 0;
            enemy.EnemyComebackText(_doubleDmgTakenTexts[Random.Range(0, _doubleDmgTakenTexts.Count)]);

        }
        else if (_enemyReaction == 0)
        {
            damage = 1;
            enemy.EnemyComebackText(_dmgTakenTexts[Random.Range(0, _dmgTakenTexts.Count)]);
        }
        else
        {
            damage = 2;
            enemy.EnemyComebackText(_halfDmgTakenTexts[Random.Range(0, _halfDmgTakenTexts.Count)]);
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
