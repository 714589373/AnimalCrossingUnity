using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public string itemDescription;
    public int itemID;
    public Sprite itemSprite;

	public Item()
    {

    }

    public Item(string iName, string iDescription, int id, Sprite iSprite)
    {
        itemName = iName;
        itemDescription = iDescription;
        itemID = id;
        itemSprite = iSprite;
    }
}
