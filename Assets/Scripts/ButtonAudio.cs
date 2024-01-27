using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _hoverAudio;
    [SerializeField] private AudioClip _clickAudio;



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
