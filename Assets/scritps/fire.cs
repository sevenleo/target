using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

    public GameObject bullet_prefab;
    GameObject bullet;
    float z;
    public bool player;
    Vector3 mouseposition;

    Vector3 moveto;
    Vector3 direction;
    Vector3 scale;
    LineRenderer lineRenderer;
    float startWidth = 1.0f;
    float endWidth = 1.0f;
    float threshold = 0.001f;
    Camera thisCamera;
    Vector3 lastPos = Vector3.one * float.MaxValue;

    // Use this for initialization
    void Start () {
        z = transform.position.z;
        //gameObject.AddComponent<LineRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        if (player)
        {
            lineRenderer.material.color = Color.blue;
        }
        else
        {
            lineRenderer.material.color = new Color(0.9f, 0.9f, 0.9f, 0.5f);
        }
    }
	
	// Update is called once per frame
	void Update () {

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        if (player == variables.turno)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetWidth(startWidth, endWidth);
            lineRenderer.SetVertexCount(2);
            direction = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, direction);

            if(Input.GetMouseButtonDown(1)){
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0;

            }

            if (Input.GetMouseButtonUp(1))
            {
                bullet = Instantiate<GameObject>(bullet_prefab);
                bullet.transform.position = transform.position;
                scale = mouseposition - transform.position;
                float speed = scale.magnitude * 0.3f; //maxspeed
                bullet.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }

        
    }
}
