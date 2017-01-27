using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class face : MonoBehaviour
{
    RaycastHit hit;
    public Text textbox;
    public Canvas chatScreen;
    public Canvas inventoryScreen;
    public KeyCode inventoryButton;
    private bool invOpen = false;
    PlayerManager pm;
	// Use this for initialization
	void Start ()
    {
        textbox = chatScreen.transform.GetChild(1).gameObject.GetComponent<Text>();
        //testing
        inventoryButton = KeyCode.Tab;
        inventoryScreen.gameObject.SetActive(false);
        chatScreen.gameObject.SetActive(false);
        pm = gameObject.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, transform.right, Color.red);
        if (Physics.Raycast(transform.position, transform.right, out hit, 1f))
        {
            if(hit.transform.tag == "Door" & Input.GetKeyDown(KeyCode.E))
            {
                transform.parent.transform.position = hit.transform.gameObject.GetComponent<doorAttributes>().destination;
            } else if(hit.transform.tag == "NPC" & Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.GetChild(0).LookAt(transform.parent);
                //transform.parent.gameObject.GetComponent<PlayerMovement>().canMove = false;
                hit.transform.gameObject.GetComponent<NPC>().Chat(chatScreen.gameObject, textbox, pm.name, transform.parent.gameObject.GetComponent<PlayerMovement>());
                //transform.parent.gameObject.GetComponent<PlayerMovement>().canMove = true;
            }
        }
        if(Input.GetKeyDown(inventoryButton))
        {
            if (invOpen == false)
            {
                inventoryScreen.gameObject.SetActive(true);
                transform.parent.gameObject.GetComponent<PlayerMovement>().canMove = false;
                invOpen = true;
            } else
            {
                inventoryScreen.gameObject.SetActive(false);
                transform.parent.gameObject.GetComponent<PlayerMovement>().canMove = true;
                invOpen = false;
            }
        }
	}
}
