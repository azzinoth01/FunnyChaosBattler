using System;
using UnityEngine;

[Serializable]
public class CardEffect
{


    [SerializeField] private int _value;
    [SerializeField] private TypeEnum _type;
    [SerializeField] private SkillTypeEnum _skillType;
    [SerializeField] private string _text;

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

    public string Text { get => _text; set => _text = value; }
}
