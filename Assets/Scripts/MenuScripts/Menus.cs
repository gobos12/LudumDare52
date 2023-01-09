using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    [Header("Buttons")]
    public Button inventoryButton;
    public Button closeInventoryButton;

    [Header("Menus")]
    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryButton.onClick.AddListener(delegate
            {
                inventoryMenu.gameObject.SetActive(true);
<<<<<<< Updated upstream
                inventoryButton.gameObject.SetActive(false);
=======
                //sound
                FindObjectOfType<AudioManager>().Play("Button Click");
                
>>>>>>> Stashed changes
            }
        );

        closeInventoryButton.onClick.AddListener(delegate
            {
                inventoryMenu.gameObject.SetActive(false);
<<<<<<< Updated upstream
                inventoryButton.gameObject.SetActive(true);
            }
        );
=======
                marketMenu.gameObject.SetActive(false);

                FindObjectOfType<AudioManager>().Play("Button Click");
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

                FindObjectOfType<AudioManager>().Play("Button Click");
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
                            FindObjectOfType<AudioManager>().Play("BuySell");
                        }
                    }
                }
            }
        );

        hintButton.onClick.AddListener(delegate
            {
                Time.timeScale = 0;
                tutorialMenu.SetActive(true);

                FindObjectOfType<AudioManager>().Play("Button Click");
            }
        );

        startButton.onClick.AddListener(delegate
            {
                Time.timeScale = 1;
                tutorialMenu.SetActive(false);

                FindObjectOfType<AudioManager>().Play("Button Click");
            }  
        );
>>>>>>> Stashed changes
    }
}
