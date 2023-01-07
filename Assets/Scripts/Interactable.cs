using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onInteract;

    public void OnPointerClick(PointerEventData eventData)
    {
        onInteract.Invoke();
        Debug.Log("clicking");
    }

}
