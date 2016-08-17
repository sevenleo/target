using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    float z;
    int speed = 15;
    public bool player;
    Vector3 mouseposition;
    float minimaldistance = 11;

	// Use this for initialization
	void Start () {
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        if ( player==variables.turno  &&  Vector3.Distance(mouseposition,transform.position) < minimaldistance )
        {
            if (Input.GetMouseButton(0) && Vector2.Distance(mouseposition, transform.position) > 0)
            {
                transform.position = mouseposition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            }

            if (Input.GetMouseButton(1))
            {
            }
        }


        if (player == variables.turno)        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }



        }
}
