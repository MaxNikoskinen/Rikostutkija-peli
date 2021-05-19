using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Map,
        PaperNote,
        Trollface,
    }

    public ItemType itemType;
    public int amount;
}
