using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HandObejct : MonoBehaviour
{
    [SerializeField] private List<Button> _cardButtons;


    // Start is called before the first frame update
    void Start()
    {
        int counter = 0;
        foreach (Button button in _cardButtons)
        {
            Card card = GlobalGameInstance.Instance.CardData.Values.ToArray()[counter];
            button.onClick.AddListener(() => UseCard(card.Id));
            counter = counter + 1;
        }
    }



    private void UseCard(int cardId)
    {
        Card card = GlobalGameInstance.Instance.CardData[cardId];


        foreach (CardEffect effect in card.CardEffects)
        {

            Debug.Log(effect.Type);
            if (effect.SkillType == SkillTypeEnum.Humor)
            {
                GlobalGameInstance.Instance.Enemy.LaughterDamage(effect.Value, effect.Type);
            }
            else
            {
                GlobalGameInstance.Instance.Enemy.TakeDamage(effect.Value, effect.Type);
            }
        }

        if (GlobalGameInstance.Instance.Enemy.Hp <= 0)
        {
            GlobalGameInstance.Instance.WinScreen.SetActive(true);
        }
        else
        {
            GlobalGameInstance.Instance.TurnHandler.EndTurn();

        }

    }

}
