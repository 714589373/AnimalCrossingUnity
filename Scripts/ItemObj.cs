using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
    public Item item;
    private Transform startParent;
    private GameObject slotParent;
    private CanvasGroup canvasGroup;
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.SetParent(transform.parent.parent);

        //disable block raycast, damit die umrandung bei anderen slots funktioniert
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetSlotInfo();
        //enable block raycast, damit das draggen wieder funktioniert
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    private void GetSlotInfo()
    {
        

        for (int i = 0; i < slotParent.transform.childCount; i++)
        {
            if (slotParent.transform.GetChild(i).GetComponent<SlotOutline>().isSelected == true)
            {
                if (slotParent.transform.GetChild(i).transform.childCount > 0)
                {
                    //Getting ItemObj of other slot
                    ItemObj otherItem = slotParent.transform.GetChild(i).transform.GetChild(0).GetComponent<ItemObj>();

                    //Save otherItem's parent
                    Transform otherItemParent = otherItem.startParent;

                    //set otherItem's parent to our
                    otherItem.startParent = startParent;
                    otherItem.transform.SetParent(otherItem.startParent);
                    otherItem.transform.localPosition = Vector2.zero;
                    //set our parent to saved parent
                    startParent = otherItemParent;
                }
                else
                {
                    startParent = slotParent.transform.GetChild(i).transform;

                }
                break;
            }
        }
        transform.SetParent(startParent);
        transform.localPosition = Vector2.zero;
    }

    // Use this for initialization
    void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
        slotParent = transform.parent.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
