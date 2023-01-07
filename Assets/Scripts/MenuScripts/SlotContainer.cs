using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlotContainer
{
    public Sprite itemSprite; //sprite of item inside of slot
    public int itemCount; //number of items inside of slot
    [HideInInspector] public int tableID;
    [HideInInspector] public SlotTemplate slot;
}
