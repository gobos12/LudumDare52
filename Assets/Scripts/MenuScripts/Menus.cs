using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    [Header("Buttons")]
    public Button inventoryButton;
    public Button closeInventoryButton;
    public Button blackMarketButton;

    [Header("Menus")]
    public GameObject inventoryMenu;
    public GameObject blackMarketMenu;

    private void Start()
    {
        inventoryButton.onClick.AddListener(delegate
            {
                inventoryMenu.gameObject.SetActive(true);
                inventoryButton.gameObject.SetActive(false);
                blackMarketButton.gameObject.SetActive(false);
            }
        );

        closeInventoryButton.onClick.AddListener(delegate
            {
                inventoryMenu.gameObject.SetActive(false);
                blackMarketMenu.gameObject.SetActive(false);
                inventoryButton.gameObject.SetActive(true);
                blackMarketButton.gameObject.SetActive(true);
            }
        );

        blackMarketButton.onClick.AddListener(delegate
            {
                blackMarketMenu.gameObject.SetActive(true);
                inventoryMenu.gameObject.SetActive(true);
                inventoryButton.gameObject.SetActive(false);
                blackMarketButton.gameObject.SetActive(false);
            }
        );
    }
}
