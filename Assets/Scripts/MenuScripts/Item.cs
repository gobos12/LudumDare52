using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string name;
    public Sprite itemSprite;
    public int cost;
    public bool stackable = false; //can the item be stacked?   
    public bool sellable;
    public GameObject plantObject;
    public bool isWard;
}
