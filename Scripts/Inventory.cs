using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Inventory : MonoBehaviour {
    public int slots;
    public GameObject slotPrefab;
    public Transform slotParent;
    private InventoryDatabase db;
    public GameObject itemPrefab;
    public List<GameObject> slotList = new List<GameObject>();
	// Use this for initialization
	void Start () {
        db = GameObject.FindGameObjectWithTag("InventoryDatabase").GetComponent<InventoryDatabase>();
        
		for (int i = 0; i < slots; i++)
        {
            slotList.Add(Instantiate(slotPrefab));
            slotList[i].transform.SetParent(slotParent);
        }
	}

    public void addItem(int id)
    {
        Item item = db.getItemById(id);
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].transform.childCount <= 0)
            {
                Debug.Log("Found a free one.");
                GameObject newItem = Instantiate(itemPrefab);
                newItem.GetComponent<Image>().sprite = item.itemSprite;
                newItem.GetComponent<ItemObj>().item = item;
                newItem.transform.SetParent(slotList[i].transform);
                newItem.transform.localPosition = Vector2.zero;
                Debug.Log("Added item: " + item.itemName);
                break;
            }
        }
        return;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.P))
        {
            // testing feature, add bells
            addItem(0);
        }
	}
}
