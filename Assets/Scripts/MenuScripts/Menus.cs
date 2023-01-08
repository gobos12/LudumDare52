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

    [Header("Menus")]
    public GameObject inventoryMenu;
    public GameObject marketMenu;

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
    }
}
