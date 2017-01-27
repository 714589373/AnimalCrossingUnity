using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDatabase : MonoBehaviour {
    public List<Item> db = new List<Item>();
	// Use this for initialization
	void Start () {
        db.Add(new Item("Bell", "Money", 0, Resources.Load<Sprite>("Sprites/bells")));
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}

    public Item getItemById(int id)
    {
        Debug.Log("Trying to get itemID: " + id);
        foreach(Item itm in db)
        {
            if(itm.itemID == id)
            {
                Debug.Log("Found item!");
                return itm;
            }
        }
        Debug.LogError("Couldn't find item with ID: " + id);
        return null;
    }
}
