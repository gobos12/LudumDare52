using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public Sprite itemSprite;
    public bool stackable = false; //can the item be stacked?   


    public GameObject plantObject;
}
