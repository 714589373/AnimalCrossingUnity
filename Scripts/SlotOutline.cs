using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotOutline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
	private Outline outline;

	public bool isSelected = false;


	private void Start()
	{
		outline = GetComponent<Outline>();
		outline.enabled = false;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		outline.enabled = true;
		isSelected = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		outline.enabled = false;
		isSelected = false;
	}


}
