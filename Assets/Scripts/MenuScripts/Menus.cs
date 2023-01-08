using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    [Header("Buttons")]
    public Button inventoryButton;
    public Button closeInventoryButton;
    public Button marketButton;
    public Button sellButton;
    public Button hintButton;
    public Button startButton;

    [Header("Menus")]
    public GameObject inventoryMenu;
    public GameObject marketMenu;
    public GameObject tutorialMenu;

    private void Start()
    {
        inventoryButton.onClick.AddListener(delegate
            {
                //buttons
                inventoryButton.gameObject.SetActive(false);
                marketButton.gameObject.SetActive(false);
                //menus
                inventoryMenu.gameObject.SetActive(true);
                
            }
        );

        closeInventoryButton.onClick.AddListener(delegate
            {
                //buttons
                inventoryButton.gameObject.SetActive(true);
                marketButton.gameObject.SetActive(true);
                //menus
                inventoryMenu.gameObject.SetActive(false);
                marketMenu.gameObject.SetActive(false);
            }
        );

        marketButton.onClick.AddListener(delegate
            {
                //buttons
                inventoryButton.gameObject.SetActive(false);
                marketButton.gameObject.SetActive(false);
                //menus
                inventoryMenu.gameObject.SetActive(true);
                marketMenu.gameObject.SetActive(true);
            }
        );

        sellButton.onClick.AddListener(delegate
            {
                for(int i = 0; i < Inventory.singleton.sellSlots.Length; i++){
                    //removes all items from inventory IF it is sellable
                    Item item = Inventory.singleton.FindItem(Inventory.singleton.sellSlots[i].itemSprite);
                    if(item != null){
                        if(item.sellable){
                            Currency.singleton.AddMoney(item.cost * Inventory.singleton.sellSlots[i].itemCount);
                            Inventory.singleton.RemoveItem(Inventory.singleton.sellSlots[i]);
                            Inventory.singleton.UpdateItems(Inventory.singleton.sellSlots);
                        }
                    }
                }
            }
        );

        hintButton.onClick.AddListener(delegate
            {
                Time.timeScale = 0;
                tutorialMenu.SetActive(true);
            }
        );

        startButton.onClick.AddListener(delegate
            {
                Time.timeScale = 1;
                tutorialMenu.SetActive(false);
            }  
        );
    }
}
