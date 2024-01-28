public class HandObejct : MonoBehaviour
{
    [SerializeField] private List<Button> _cardButtons;
    public GameObject currentlyHoveredCard;
    public GameObject nextHoveredCard;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _attackSounds;
    [SerializeField] private List<AudioClip> _impacktSounds;

>>>>>>>>> Temporary merge branch 2

    // Start is called before the first frame update
    void Start()
    {
        int counter = 0;
        foreach (Button button in _cardButtons)
        {
            Card card = GlobalGameInstance.Instance.CardData.Values.ToArray()[counter];
            button.onClick.AddListener(() => UseCard(card.Id, button.gameObject));
            HandHover handHoverVar = button.gameObject.GetComponent<HandHover>();

            handHoverVar.SetPositionOnHand(counter);
            counter = counter + 1;
        }
    }



    private void UseCard(int cardId, GameObject button)
    {


        Card card = GlobalGameInstance.Instance.CardData[cardId];

        StartCoroutine(AttackSound(card));




        button.gameObject.SetActive(false);

        GlobalGameInstance.Instance.TurnHandler.InvokeTurnChangeEvent();

    }

    private IEnumerator AttackSound(Card card)
    {
        _audioSource.clip = _attackSounds[Random.Range(0, _attackSounds.Count)];

        _audioSource.Play();

        yield return new WaitForSeconds(_audioSource.clip.length);

        _audioSource.clip = _impacktSounds[Random.Range(0, _impacktSounds.Count)];
        _audioSource.Play();

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
