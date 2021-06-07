using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Map,
        PaperNote,
        Flashlight,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flashlight:        return ItemAssets.Instance.flashlightSprite;
            case ItemType.Map:               return ItemAssets.Instance.mapSprite;
            case ItemType.PaperNote:         return ItemAssets.Instance.paperNoteSprite;
        }
    }
}
