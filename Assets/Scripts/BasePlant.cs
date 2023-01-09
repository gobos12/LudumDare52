using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasePlant : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float timeToMoveStage;
    private float growthTimer;
    private int currentStage = 0;
    [SerializeField] private float freshTime;
    [SerializeField] private float durability;
    [SerializeField] private float baseValue;

    [SerializeField] private Sprite sprouting;
    [SerializeField] private Sprite fresh;
    [SerializeField] private Sprite wilted;
    
    private float quality;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
=======
        seed = GetComponent<Image>().sprite;
        FindObjectOfType<AudioManager>().Play("Plant");
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        growthTimer += Time.deltaTime;
        if (growthTimer > timeToMoveStage && currentStage < 2) // if perfect stage or wilted dont increment
        {
            growthTimer = 0;
            currentStage++;
            switch (currentStage)
            {
                case 1:
                    GetComponent<Image>().sprite = sprouting;
                    break;
                case 2:
                    GetComponent<Image>().sprite = fresh;
                    break;
            }
        } else if (currentStage == 2 && growthTimer > freshTime)
        {
            growthTimer = 0;
            currentStage++;
            GetComponent<Image>().sprite = wilted;
        }

        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
<<<<<<< Updated upstream
        // calculate value, add to inventory
        Debug.Log("test");
        Destroy(gameObject);
=======
        if (currentStage == 2 && currentGhostState != GhostState.BeingEaten)
        {
            Inventory.singleton.AddItem(gameObject);
            FindObjectOfType<AudioManager>().Play("Harvest");
        }

        try
        {
            if (Inventory.singleton.FindItem(Inventory.singleton.SelectedItemSlot.itemSprite).isWard)
            {
                ghost.SetActive(false);
                currentGhostState = GhostState.Unprotected;
            } else if (Inventory.singleton.FindItem(Inventory.singleton.SelectedItemSlot.itemSprite).name == "Shovel" && currentStage == 3)
            {
                gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Play("Shovel");
            } else if (Inventory.singleton.FindItem(Inventory.singleton.SelectedItemSlot.itemSprite).name == "Ashes")
            {
                Inventory.singleton.SelectedItemSlot.itemCount--;
                if (Inventory.singleton.SelectedItemSlot.itemCount <= 0)
                {
                    Inventory.singleton.SelectedItemSlot.itemSprite = null;
                }
                Inventory.singleton.UpdateItems(Inventory.singleton.inventorySlots);
                Inventory.singleton.UpdateItems(Inventory.singleton.plantSlots);
                Inventory.singleton.UpdateItems(Inventory.singleton.sellSlots);
                freshTime += 5;
            } else if (Inventory.singleton.FindItem(Inventory.singleton.SelectedItemSlot.itemSprite).name == "Blue Flame")
            {
                Debug.Log("getting here");
                Inventory.singleton.SelectedItemSlot.itemCount--;
                if (Inventory.singleton.SelectedItemSlot.itemCount <= 0)
                {
                    Inventory.singleton.SelectedItemSlot.itemSprite = null;
                }
                Inventory.singleton.AddItem(ashes);
                Inventory.singleton.UpdateItems(Inventory.singleton.inventorySlots);
                Inventory.singleton.UpdateItems(Inventory.singleton.plantSlots);
                Inventory.singleton.UpdateItems(Inventory.singleton.sellSlots);
                gameObject.SetActive(false);
            }
        }
        catch (NullReferenceException e)
        {
        }
>>>>>>> Stashed changes
    }

    private float GetItemValue()
    {
        if (currentStage == 3) return 0;
        return baseValue * (currentStage + 1) / 2;
    }
}
