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
        if (gameObject.GetComponent<BasePlant>() != null)
        {
            gameObject.GetComponent<BasePlant>().OnPointerClick();
        } else if (gameObject.GetComponent<Scarecrow>() != null)
        {
            Inventory.singleton.AddItem(gameObject);
        }
        //Inventory.singleton.AddItem(gameObject);
    }

}
