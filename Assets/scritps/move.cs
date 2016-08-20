using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class move : MonoBehaviour {
    float z;
    int speed = 15;
    public bool player;
    Vector3 mouseposition;
    Vector3 moveto;
    Vector3 screen;

    // Use this for initialization
    void Start () {
        variables.movelock = false;
        variables.minimaldistance = 0.1f * transform.localScale.x;
        variables.debug+="MinimalDistance: " + variables.minimaldistance;
        z = transform.position.z;
        screen = new Vector3(Screen.width, Screen.height,z);
        screen = Camera.main.ScreenToWorldPoint(screen);
    }
	
	// Update is called once per frame
	void Update () {



        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);


        if (player == variables.turno)
        {
            if (variables.movelock) transform.position = mouseposition;


            if (onScreen())
            {
                if (Vector2.Distance(mouseposition, transform.position) < variables.minimaldistance && Input.GetMouseButtonDown(0))
                {
                    variables.movelock = true;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<Rigidbody2D>().angularVelocity = 0;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    variables.movelock = false;
                }

                moveto = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
                transform.position += moveto * speed * Time.deltaTime;
            }

            variables.debug2 = "Distance: " + Vector2.Distance(mouseposition, transform.position).ToString("F3");
        }
        




    }

    bool onScreen()
    {
        /*
        if (Math.Abs(transform.position.x) > screen.x - variables.minimaldistance)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //transform.position = new Vector3(screen.x - variables.minimaldistance, transform.position.y, transform.position.z);
        }

        if (Math.Abs(transform.position.y) > screen.y - variables.minimaldistance)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //transform.position = new Vector3(transform.position.x, screen.y - variables.minimaldistance, transform.position.z);
        }

       


        if (Math.Abs(transform.position.y) <= screen.y && Math.Abs(transform.position.x) <= screen.x)
        {
            variables.debug2 = "ret: true\n";
            variables.debug2 += transform.position + "\n screen: " + screen;
            variables.debug2 += "Distance: " + Vector2.Distance(mouseposition, transform.position).ToString("F3");


            return true;
        }
        else
        {
            variables.debug2 = "ret: false\n";
            variables.debug2 += transform.position+"\n screen: "+ screen;
            variables.debug2 += "Distance: " + Vector2.Distance(mouseposition, transform.position).ToString("F3");

            return false;
        }
         */
        return true;
    }
}
