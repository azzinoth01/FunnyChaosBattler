using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
    

public class HandHover : MonoBehaviour
{
    public int currentHandPosition = 0;
    public Vector3 startingScale, newScale;
    public GameObject thisGameObject;
    public static bool pointerIsEntered = false;
    public HandObejct Hand;

    private void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        startingScale = new Vector3(1, 1, 1);
        newScale = new Vector3(4, 4, 4);
    }

    IEnumerator WaitBetweenCards()
    {
        yield return new WaitForSeconds(1);
        pointerIsEntered = false;
    }
    public void SetPositionOnHand(int _handPosition)
    {
        currentHandPosition = _handPosition;
        transform.SetSiblingIndex(currentHandPosition);
    }

    public void OnPointerEnter()
    {
        transform.localScale = newScale;
        if (Hand.currentlyHoveredCard != null)
        {
            Hand.nextHoveredCard = gameObject;
        }
        else
        {
            Hand.currentlyHoveredCard = gameObject;
            transform.SetAsLastSibling();
        }
    }

    public void OnPointerExit()
    {
        transform.localScale = startingScale;
        if(Hand.currentlyHoveredCard == gameObject)
        {
            Hand.currentlyHoveredCard = null;
            if(Hand.nextHoveredCard != null)
            {
                Hand.nextHoveredCard.transform.SetAsLastSibling();
                Hand.currentlyHoveredCard = Hand.nextHoveredCard;
                Hand.nextHoveredCard = null;
            }
        }
        else if(Hand.nextHoveredCard == gameObject)
        {
            Hand.nextHoveredCard = null;
        }
        transform.SetSiblingIndex(currentHandPosition);
    }
}
