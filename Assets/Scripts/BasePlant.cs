using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasePlant : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float timeToMoveStage;
    private float growthTimer;
    private int currentStage = 0;
    [SerializeField] private float freshTime;
    [SerializeField] private float durability;
    [SerializeField] private float baseValue;

    [Header("Animation Sprites")]
    [SerializeField] private Sprite sprouting;
    [SerializeField] private Sprite fresh;
    [SerializeField] private Sprite wilted;

    [Header("Inventory Sprites")] 
    [SerializeField] private Sprite seedSprite;
    [SerializeField] private Sprite grownSprite;
    
    
    private float quality;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Interactable>().onInteract.AddListener((() =>
        {
            Inventory.singleton.AddItem(gameObject);
        }));
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

    public void OnPointerClick()
    {
        // calculate value, add to inventory
        GetComponent<Image>().sprite = grownSprite;
    }

    private float GetItemValue()
    {
        if (currentStage == 3) return 0;
        return baseValue * (currentStage + 1) / 2;
    }
}
