using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    public GameObject inventoryScreen;
    public PlayerMovementCC playerMovementScript;
    public MouseLookCC mouseLookScript;
    private bool isOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isOpen == false)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
        inventory.onItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 150f;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                inventory.UseItem(item);
            };
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Item Icon").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }




    public void OpenInventory()
    {
        isOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        inventoryScreen.SetActive(true);
        mouseLookScript.allowLooking = false;
    }

    public void CloseInventory()
    {

        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventoryScreen.SetActive(false);
        mouseLookScript.allowLooking = true;
    }


    public void AddItemMap()
    {
        inventory.AddItem(new Item { itemType = Item.ItemType.Map, amount = 1 });
    }

}
