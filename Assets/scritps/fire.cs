using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

    public GameObject bullet_prefab;
    GameObject bullet;
    float z;
    public bool player;
    Vector3 mouseposition;
    float speed;
    Vector3 moveto;
    Vector3 direction;
    Vector3 scale;
    LineRenderer lineRenderer;
    float startWidth = 1.0f;
    float endWidth = 1.0f;
    float threshold = 0.001f;
    Camera thisCamera;
    Vector3 lastPos = Vector3.one * float.MaxValue;
    float collisionTime;
    Vector3 one = new Vector3(1, 1, 0);

    // Use this for initialization
    void Start () {
        z = transform.position.z;
        lineRenderer = GetComponent<LineRenderer>();
        /*if (player)
        {
            lineRenderer.material.color = Color.blue;
        }
        else
        {
            lineRenderer.material.color = new Color(0.9f, 0.9f, 0.9f, 0.5f);
        }*/
    }
	
	// Update is called once per frame
	void Update () {

       // if (collisionTime + 1f < Time.time)
         //   Camera.main.backgroundColor = Color.red;

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);



        if (player == variables.turno)
        {
            if (variables.movelock)
                lineRenderer.enabled = false;
            else
                lineRenderer.enabled = true;
            lineRenderer.SetWidth(startWidth, endWidth);
            lineRenderer.SetVertexCount(2);
            direction = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
            Vector2 position = transform.position;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, direction);
            

            if (Input.GetMouseButtonDown(0)){
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
            }

            if (Input.GetMouseButton(0) && Vector2.Distance(mouseposition, transform.position) >= variables.minimaldistance)
            {
                bullet = Instantiate<GameObject>(bullet_prefab);
                bullet.tag = player ? "p1" : "p2";
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
                bullet.transform.position = transform.position;
                scale = mouseposition - transform.position;
                speed = scale.magnitude * 0.2f; //maxspeed
                bullet.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
                Color randomcolor = new Color(0, Random.Range(0, 0.4f), Random.Range(.6f, 1f), Random.Range(.3f, 1f));
                bullet.GetComponent<SpriteRenderer>().color = randomcolor;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = randomcolor;
                lineRenderer.SetColors(randomcolor, Color.black);
                //bullet.transform.SetParent (gameObject.transform);
                Destroy(bullet, 8);
            }else
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                lineRenderer.SetColors(Color.white, Color.white);

            }
        }
        else
        {
            lineRenderer.enabled = false;
        }

        
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != gameObject.tag)
        {
            //coll.gameObject.transform.parent.transform.localScale = coll.gameObject.transform.parent.transform.localScale + one;
            
            //Camera.main.backgroundColor = Color.red;
            //collisionTime = Time.time;
        }




    }

}
