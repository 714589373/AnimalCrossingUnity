using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public string greeting;
    public string name;
    public string favoriteWord;
    public int nmbrWindows;
    public List<string> msgs = new List<string>();
    public List<string> friends = new List<string>();
    public int counter = 0;
	// Use this for initialization
	void Start () {
        msgs.Add("I like turtles.");
        msgs.Add("Hi");
        nmbrWindows += 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void Chat(GameObject canv, Text textbox, string playerName, PlayerMovement pm)
    {
        if (friends.Contains(playerName))
        {
            canv.SetActive(true);
            pm.canMove = false;
            try
            {
                textbox.text = msgs[counter];
            } catch (Exception ex) { }
            counter += 1;
            if (counter > msgs.Count)
            {
                counter = 0;
                pm.canMove = true;
                canv.SetActive(false);
            }
            
        } else
        {
          
            canv.SetActive(true);
            pm.canMove = false;
            textbox.text = greeting + name + ", " + favoriteWord;
            
            counter += 1;
            if(counter == 2)
            {
                counter = 0;
                pm.canMove = true;
                canv.SetActive(false);
                friends.Add(playerName);
            }
        }
    }
}
