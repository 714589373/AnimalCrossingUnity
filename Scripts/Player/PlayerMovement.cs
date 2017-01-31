using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Camera camera;
    public GameObject camObj;
    public Transform model;
    public float speed;
    public bool canMove = true;
    private Animator anim;
	// Use this for initialization
	void Start ()
    {
        camera = camObj.GetComponent<Camera>();
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (canMove)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            if(x != 0)
            {
                anim.SetFloat("speed", Mathf.Abs(x) * speed);
            } else
            {
                anim.SetFloat("speed", Mathf.Abs(y) * speed);
            }
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed));
            if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
                model.eulerAngles = new Vector3(-90, Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * -180 / Mathf.PI, 0);
        }

    }
}
