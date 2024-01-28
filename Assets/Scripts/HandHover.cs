using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
    

public class HandHover : MonoBehaviour
{
    public int currentHandPosition = 0;
    public Vector3 startingScale, newScale;
    public Vector3 spawnPos; 
    public Quaternion spawnRot;
    public GameObject thisGameObject;
    public static bool pointerIsEntered = false;
    public HandObejct Hand;

    private void Start()
    {
        spawnPos = transform.localPosition;
        spawnRot = transform.localRotation;
        EventTrigger trigger = GetComponent<EventTrigger>();
        startingScale = new Vector3(1, 1, 1);
        newScale = new Vector3(2, 2, 2);
    }

    private void ResetToStart()
    {
        transform.localPosition = spawnPos;
        transform.localRotation = spawnRot;
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
        transform.localPosition += new Vector3(0, 383, 0);
        transform.localRotation = new Quaternion(0, 0, 0, 0);
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
        ResetToStart();
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
