using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardEffect
{
    [SerializeField] private int _value;
    [SerializeField] private TypeEnum _type;
    [SerializeField] private SkillTypeEnum _skillType;
    [SerializeField] private List<string> _text;

    [SerializeField] private List<float> _textDelay;

    public int Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
        }
    }

    public TypeEnum Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }

    public SkillTypeEnum SkillType
    {
        get
        {
            return _skillType;
        }

        set
        {
            _skillType = value;
        }
    }

    public List<string> Text
    {
        get
        {
            return _text;
        }

        set
        {
            _text = value;
        }
    }

    public List<float> TextDelay
    {
        get
        {
            return _textDelay;
        }

        set
        {
            _textDelay = value;
        }
    }
}
