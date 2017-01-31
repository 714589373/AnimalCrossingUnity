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
    private Animator anim;
    public List<string> msgs = new List<string>();
    public List<string> friends = new List<string>();
    public int counter = 0;
    public Transform model;
    
    public bool moving;
    private bool canMove = true;
    private float walkTime = 5f;
    private float walkSpeed = 1.5f;
    private float randomMovement;

    private float speed = 3f;
    System.Random rnd = new System.Random();
	// Use this for initialization
	void Start () {
        msgs.Add("I like turtles.");
        msgs.Add("Hi");
        nmbrWindows += 2;
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canMove)
        {

            /*if (x != 0)
            {
                anim.SetFloat("speed", Mathf.Abs(x) * speed);
            }
            else
            {
                anim.SetFloat("speed", Mathf.Abs(y) * speed);
            }*/
            walkTime -= Time.deltaTime;
            if (moving == true)
            {
                transform.Translate(0f, 0f, walkSpeed * Time.deltaTime);
            }

            if (walkTime <= 0)
                Move();
        }
    }

    private void Move()
    {
        randomMovement = UnityEngine.Random.Range(0, 370);
        if (randomMovement >= 360)
        {
            moving = false;
            walkTime = 5f;
        }
        if (randomMovement <= 360)
        {
            moving = true;
            walkTime = 5f;
            transform.eulerAngles = new Vector3(0, randomMovement, 0);
        }
    }

    public void Chat(GameObject canv, Text textbox, string playerName, PlayerMovement pm)
    {
        if (friends.Contains(playerName))
        {
            canv.SetActive(true);
            pm.canMove = false;
            canMove = false;
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
                canMove = true;
            }
            
        } else
        {
          
            canv.SetActive(true);
            pm.canMove = false;
            textbox.text = greeting + name + ", " + favoriteWord;
            canMove = false;
            counter += 1;
            if(counter == 2)
            {
                counter = 0;
                pm.canMove = true;
                canv.SetActive(false);
                friends.Add(playerName);
                canMove = true;
            }
        }
    }
}
