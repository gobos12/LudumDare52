using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject DragObj;
    [SerializeField] private GameObject plantSpawn;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        DragObj.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragObj.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Object.Instantiate(plantSpawn, DragObj.transform.position, DragObj.transform.rotation);
        DragObj.SetActive(false);
    }
}
