using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour
{
    [SerializeField] private AudioClip _hoverAudio;
    [SerializeField] private AudioClip _clickAudio;


    // Start is called before the first frame update
    void Start()
    {
        GlobalGameInstance.Instance.TurnHandler.turnChange += ToogleEnable;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        GlobalGameInstance.Instance.TurnHandler.turnChange -= ToogleEnable;
    }

    private void ToogleEnable()
    {
        Button button = gameObject.GetComponent<Button>();
        button.interactable = !button.interactable;

    }

    public void OnHover()
    {

        AudioSource source = gameObject.GetComponent<AudioSource>();

        source.clip = _hoverAudio;

        source.Play();
    }

    public void OnClick()
    {
        //AudioSource source = gameObject.GetComponent<AudioSource>();

        //source.clip = _clickAudio;

        //source.Play();

        AudioSource.PlayClipAtPoint(_clickAudio, Vector3.zero);
    }
}
