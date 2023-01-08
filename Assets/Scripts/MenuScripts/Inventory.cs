using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory singleton;
    public Item startingItem;

    [Header("Slot Containers")] public RectTransform inventorySlotsContainer;
    public RectTransform plantSlotsContainer;
    public RectTransform sellSlotsContainer;

    [Header("Slot Templates")] public SlotTemplate slotTemplate;
    public SlotTemplate plantSlotTemplate;

    [Header("Slot Lists")] public SlotContainer[] inventorySlots;
    public SlotContainer[] plantSlots;
    public SlotContainer[] sellSlots;
    public Item[] items; //array of all available items

    private SlotContainer selectedItemSlot;

    public SlotContainer SelectedItemSlot => selectedItemSlot;

    private void Start()
    {
        singleton = this;

        //sets up slot element template
        plantSlotTemplate.container.rectTransform.pivot = new Vector2(0, 1);
        plantSlotTemplate.container.rectTransform.anchorMax =
            plantSlotTemplate.container.rectTransform.anchorMin = new Vector2(0, 1);
        plantSlotTemplate.gameObject.SetActive(false);

        //sets up plant slot template
        slotTemplate.container.rectTransform.pivot = new Vector2(0, 1);
        slotTemplate.container.rectTransform.anchorMax =
            slotTemplate.container.rectTransform.anchorMin = new Vector2(0, 1);
        slotTemplate.gameObject.SetActive(false);

        //initialize inventory slots
        InitilizeSlotTable(inventorySlotsContainer, slotTemplate, inventorySlots, 32, 0);
        UpdateItems(inventorySlots);
        inventorySlots[0].itemSprite = startingItem.itemSprite;
        inventorySlots[0].itemCount = 4;
        inventorySlots[1].itemSprite = items[^2].itemSprite;
        inventorySlots[1].itemCount = 1;
        inventorySlots[2].itemSprite = items[^1].itemSprite;
        inventorySlots[2].itemCount = 1;
        UpdateItems(inventorySlots);

        //initialize plant slots
        InitilizeSlotTable(plantSlotsContainer, plantSlotTemplate, plantSlots, 120, 1);
        UpdateItems(plantSlots);

        //initialize sell slots
        InitilizeSlotTable(sellSlotsContainer, slotTemplate, sellSlots, 16, 2);
        UpdateItems(sellSlots);

        //reset slot element template
        slotTemplate.container.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        slotTemplate.container.raycastTarget =
            slotTemplate.item.raycastTarget = slotTemplate.count.raycastTarget = false;

        plantSlotTemplate.container.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        plantSlotTemplate.container.raycastTarget =
            plantSlotTemplate.item.raycastTarget = plantSlotTemplate.count.raycastTarget = false;

    }

    private void Update()
    {
        //moving items around w mouse
        if (selectedItemSlot != null)
        {
            if (!slotTemplate.gameObject.activeSelf)
            {
                slotTemplate.gameObject.SetActive(true);
                slotTemplate.container.enabled = false;

                //copy item values ontop slot template
                slotTemplate.count.color = selectedItemSlot.slot.count.color;
                slotTemplate.item.sprite = selectedItemSlot.slot.item.sprite;
                slotTemplate.item.color = selectedItemSlot.slot.item.color;
            }

            //making template slot follow mouse
            slotTemplate.container.rectTransform.position = Input.mousePosition;

            //update item count
            slotTemplate.count.text = selectedItemSlot.slot.count.text;
            slotTemplate.count.enabled = selectedItemSlot.slot.count.enabled;

        }

        else
        {
            if (slotTemplate.gameObject.activeSelf)
            {
                slotTemplate.gameObject.SetActive(false);
            }
        }
    }

    private void InitilizeSlotTable(RectTransform container, SlotTemplate tempSlotTemplate, SlotContainer[] slots,
        int margin, int tempTableID)
    {
        int resetIndex = 0;
        int tempRow = 0;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = new SlotContainer();
            }

            GameObject newSlot = Instantiate(tempSlotTemplate.gameObject, container.transform);
            slots[i].slot = newSlot.GetComponent<SlotTemplate>();
            slots[i].slot.gameObject.SetActive(true);
            slots[i].tableID = tempTableID;

            float tempX = (int)((margin + slots[i].slot.container.rectTransform.sizeDelta.x) * (i - resetIndex));
            if ((tempX + slots[i].slot.container.rectTransform.sizeDelta.x + margin) > (container.rect.width))
            {
                resetIndex = i;
                tempRow++;
                tempX = 0;
            }

            slots[i].slot.container.rectTransform.anchoredPosition = new Vector2(margin + tempX,
                -margin - ((margin + slots[i].slot.container.rectTransform.sizeDelta.y) * tempRow));

        }
    }

    //updates table UI
    public void UpdateItems(SlotContainer[] slots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Item slotItem = FindItem(slots[i].itemSprite);

            //item in slot
            if (slotItem != null)
            {
                if (!slotItem.stackable)
                {
                    slots[i].itemCount = 1;
                }

                //apply total item count
                if (slots[i].itemCount > 1)
                {
                    slots[i].slot.count.enabled = true;
                    slots[i].slot.count.text = slots[i].itemCount.ToString();
                }
                else
                {
                    slots[i].slot.count.enabled = false;
                }

                //apply item icon
                slots[i].slot.item.enabled = true;
                slots[i].slot.item.sprite = slotItem.itemSprite;
            }

            //no item in slot
            else
            {
                slots[i].slot.count.enabled = false;
                slots[i].slot.item.enabled = false;
            }
        }
    }

    //finds item from the items list using sprite as reference
    public Item FindItem(Sprite sprite)
    {
        if (!sprite)
        {
            return null;
        }

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemSprite == sprite)
            {
                return items[i];
            }
        }

        return null;
    }

    private SlotContainer GetClickedSlot()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].slot.hasClicked)
            {
                inventorySlots[i].slot.hasClicked = false;
                return inventorySlots[i];
            }
        }

        for (int i = 0; i < plantSlots.Length; i++)
        {
            if (plantSlots[i].slot.hasClicked)
            {
                plantSlots[i].slot.hasClicked = false;
                return plantSlots[i];
            }
        }

        for (int i = 0; i < sellSlots.Length; i++)
        {
            if (sellSlots[i].slot.hasClicked)
            {
                sellSlots[i].slot.hasClicked = false;
                return sellSlots[i];
            }
        }

        return null;
    }

    public void ClickEventRecheck()
    {
        if (selectedItemSlot == null)
        {
            //gets clicked slot
            selectedItemSlot = GetClickedSlot();
            if (selectedItemSlot != null)
            {
                if (selectedItemSlot.itemSprite != null)
                {
                    selectedItemSlot.slot.count.color =
                        selectedItemSlot.slot.item.color = new Color(1, 1, 1, 0.5f); //changes color of slot
                }
                else
                {
                    selectedItemSlot = null;
                }
            }
        }

        else
        {
            SlotContainer newClickedSlot = GetClickedSlot();
            if (newClickedSlot != null)
            {
                bool swapPositions = false;
                bool releaseClick = true;

                if (newClickedSlot != selectedItemSlot)
                {
                    //inventory
                    //clicked on same table, different slots
                    if (newClickedSlot.tableID == selectedItemSlot.tableID)
                    {
                        //check to see if the new clicked item is the same (stack if yes, else swap)
                        if (newClickedSlot.itemSprite == selectedItemSlot.itemSprite)
                        {
                            Item slotItem = FindItem(selectedItemSlot.itemSprite);
                            //item is same and stackable
                            if (slotItem.stackable)
                            {
                                selectedItemSlot.itemSprite = null;
                                newClickedSlot.itemCount += selectedItemSlot.itemCount;
                                selectedItemSlot.itemCount = 0;
                            }
                            else
                            {
                                swapPositions = true;
                            }
                        }
                        else
                        {
                            swapPositions = true;
                        }
                    }

                    else
                    {
                        //moving to different table
                        if (newClickedSlot.tableID == 1)
                        {
                            //plant slot
                            Debug.Log("planter");
                            if (newClickedSlot.itemSprite == null)
                            {
                                //empty slot
                                Item slotItem = FindItem(selectedItemSlot.itemSprite);
                                try
                                {
                                    Instantiate(slotItem.plantObject, newClickedSlot.slot.container.transform);
                                    selectedItemSlot.itemCount--;
                                    if (selectedItemSlot.itemCount <= 0)
                                    {
                                        selectedItemSlot.itemSprite = null;
                                    }
                                }
                                catch (NullReferenceException e)
                                {

                                }
                            }
                        }
                        else if (newClickedSlot.tableID == 2)
                        {
                            //sell slot
                            Debug.Log("sell slot");
                            if (newClickedSlot.itemSprite == selectedItemSlot.itemSprite)
                            {
                                Item slotItem = FindItem(selectedItemSlot.itemSprite);
                                if (slotItem.stackable)
                                {
                                    //item is the same and stackable
                                    selectedItemSlot.itemSprite = null;
                                    newClickedSlot.itemCount += selectedItemSlot.itemCount;
                                    selectedItemSlot.itemCount = 0;
                                }
                                else
                                {
                                    swapPositions = true;
                                }
                            }

                            else
                            {
                                swapPositions = true;
                            }
                        }

                        else
                        {
                            if (newClickedSlot.itemSprite == null ||
                                newClickedSlot.itemSprite == selectedItemSlot.itemSprite)
                            {
                                //adds one item from selectedItemSlot
                                newClickedSlot.itemSprite = selectedItemSlot.itemSprite;
                                newClickedSlot.itemCount++;
                                selectedItemSlot.itemCount--;
                                if (selectedItemSlot.itemCount <= 0)
                                {
                                    selectedItemSlot.itemSprite = null;
                                }
                                else
                                {
                                    releaseClick = false;
                                }
                            }
                            else
                            {
                                swapPositions = true;
                            }
                        }
                    }
                }

                //item swap
                if (swapPositions)
                {
                    Sprite previousItemSprite = selectedItemSlot.itemSprite;
                    int previousItemCount = selectedItemSlot.itemCount;

                    selectedItemSlot.itemSprite = newClickedSlot.itemSprite;
                    selectedItemSlot.itemCount = newClickedSlot.itemCount;

                    newClickedSlot.itemSprite = previousItemSprite;
                    newClickedSlot.itemCount = previousItemCount;
                }

                //release mouse
                if (releaseClick)
                {
                    selectedItemSlot.slot.count.color = selectedItemSlot.slot.item.color = Color.white;
                    selectedItemSlot = null;
                }

                //Update UI
                UpdateItems(inventorySlots);
                UpdateItems(plantSlots);
                UpdateItems(sellSlots);
            }
        }
    }

    //adds item to inventory
    public void AddItem(GameObject obj)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            //if item exists in inventory
            if (inventorySlots[i].itemSprite == obj.GetComponent<Image>().sprite)
            {
                inventorySlots[i].itemCount++;
                UpdateItems(inventorySlots);
                obj.SetActive(false);
                return;
            }
            //if it does not exist in inventory
            else if (inventorySlots[i].itemSprite == null)
            {
                inventorySlots[i].itemSprite = obj.GetComponent<Image>().sprite;
                inventorySlots[i].itemCount = 1;
                UpdateItems(inventorySlots);
                obj.SetActive(false);
                return;
            }

            else
            {
                Debug.Log("error");
            }
        }

        //insert code for what to do when there is no more space in inventory
    }

    public void AddItem(Image image)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            //if item exists in inventory
            if (inventorySlots[i].itemSprite == image.sprite)
            {
                inventorySlots[i].itemCount++;
                UpdateItems(inventorySlots);
                return;
            }
            //if it does not exist in inventory
            else if (inventorySlots[i].itemSprite == null)
            {
                inventorySlots[i].itemSprite = image.sprite;
                inventorySlots[i].itemCount = 1;
                UpdateItems(inventorySlots);
                return;
            }

            else
            {
                Debug.Log("error");
            }
        }
    }

    public void RemoveItem(SlotContainer s)
    {
        s.itemSprite = null;
        s.itemCount = 0;
    }
    
}


