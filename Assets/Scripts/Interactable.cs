using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    //public UnityEvent onInteract; //removed for now bc unnecessary

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<BasePlant>().OnPointerClick();
        //Inventory.singleton.AddItem(gameObject);
    }

}
