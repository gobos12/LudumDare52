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
                inventoryButton.gameObject.SetActive(false);
            }
        );

        closeInventoryButton.onClick.AddListener(delegate
            {
                inventoryMenu.gameObject.SetActive(false);
                inventoryButton.gameObject.SetActive(true);
            }
        );
    }
}
