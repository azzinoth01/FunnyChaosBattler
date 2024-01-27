using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour
{


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

}
