using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler onItemListChanged;
    private List<Item> itemList;
    private UIInventory uiInventoryScript;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.PaperNote, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Flashlight, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    
}
