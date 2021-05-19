using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    private void RefreshInventoryItems()
    {
        foreach(Item item in inventory.GetItemList())
        {

        }
    }
}
