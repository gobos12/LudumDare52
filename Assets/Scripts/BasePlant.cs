using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasePlant : MonoBehaviour
{
    public string name;
    
    [Header("Parameters")]
    [SerializeField] private float timeToMoveStage;
    private float growthTimer;
    private int currentStage = 0;
    [SerializeField] private float freshTime;
    [SerializeField] private float durability;

    [Header("Animation Sprites")] 
    private Sprite seed;
    [SerializeField] private Sprite sprouting;
    [SerializeField] private Sprite fresh;
    [SerializeField] private Sprite wilted;

    [Header("Inventory Sprites")] [SerializeField]
    private GameObject ashes;
    [SerializeField] private Sprite seedSprite;
    [SerializeField] private Sprite grownSprite;

    public enum GhostState
    {
        Protected, Unprotected, BeingEaten
    }

    [HideInInspector] public GhostState currentGhostState;
    [HideInInspector] public GameObject ghost;
    
    private float quality;
    // Start is called before the first frame update
    void Start()
    {
        seed = GetComponent<Image>().sprite;
        FindObjectOfType<AudioManager>().Play("Plant");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().sprite == wilted) currentGhostState = GhostState.Protected;
        
        if (currentGhostState != GhostState.BeingEaten)
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
            }
            else if (currentStage == 2 && growthTimer > freshTime)
            {
                growthTimer = 0;
                currentStage++;
                GetComponent<Image>().sprite = wilted;
            }
        }
        else
        {
            growthTimer += Time.deltaTime / durability;
            if (growthTimer > timeToMoveStage && currentStage > 0) // if perfect stage or wilted dont increment
            {
                growthTimer = 0;
                currentStage--;
                switch (currentStage)
                {
                    case 0:
                        GetComponent<Image>().sprite = seed;
                        break;
                    case 1:
                        GetComponent<Image>().sprite = sprouting;
                        break;
                    case 2:
                        GetComponent<Image>().sprite = fresh;
                        break;
                }
            }
        }


    }

    public void OnPointerClick()
    {
        if (currentStage == 2 && currentGhostState != GhostState.BeingEaten)
        {
            Inventory.singleton.AddItem(gameObject);
            FindObjectOfType<AudioManager>().Play("Harvest");
        }

    public void OnPointerClick(PointerEventData eventData)
    {
        // calculate value, add to inventory
        Debug.Log("test");
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        if (ghost != null) ghost.SetActive(false);
    }
}
