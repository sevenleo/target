using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class move : MonoBehaviour {
    float z;
    int speed = 15;
    public bool player;
    Vector3 mouseposition;
    float minimaldistance = 20;
    Vector3 moveto;
    Vector3 screen;

    // Use this for initialization
    void Start () {
        z = transform.position.z;
        screen = new Vector3(Screen.width, Screen.height, z);
        screen = Camera.main.ScreenToWorldPoint(screen);
    }
	
	// Update is called once per frame
	void Update () {

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        if (Math.Abs(transform.position.x) >= screen.x)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (Math.Abs(transform.position.y) >= screen.y)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;


        if ( player==variables.turno  &&  Vector3.Distance(mouseposition,transform.position) < minimaldistance )
        {
            if (Input.GetMouseButton(0) && Vector2.Distance(mouseposition, transform.position) > 0)
            {
                transform.position = mouseposition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0;

            }
        }


        if (player == variables.turno)        {
            moveto = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += moveto * speed * Time.deltaTime;
        }




     }
}
