using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwordControls : MonoBehaviour {

    public Transform player;
    public ParticleSystem sparks;

    public float stability = 0.3f;
    public float speed = 100.0f;

    Rigidbody sword;

    public KeyCode leftSwing = KeyCode.Q;
    public KeyCode rightSwing = KeyCode.E;
    public KeyCode changeDirection = KeyCode.Space;

    public Text myText;

    private int myScore = 0;

	// Use this for initialization
	void Start () {
	    sword = GetComponent<Rigidbody>();
        myText.text = "[" + myScore + "]";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(leftSwing))
        {
            //sword.AddRelativeForce(Vector3.left * 10000);
        }

        if (Input.GetKeyDown(rightSwing))
        {
            //sword.AddRelativeForce(Vector3.right * 10000);
        }
        if (Input.GetKeyDown(changeDirection))
        {
           if(sword.angularVelocity.y < 0)
               sword.AddRelativeForce(Vector3.right * 10000);
           else if (sword.angularVelocity.y > 0)
               sword.AddRelativeForce(Vector3.left * 10000);
        }


        if(Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance;
            if(plane.Raycast(ray, out distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);
                Debug.DrawLine(player.position, hitPoint);

                //sword.AddRelativeForce(Vector3.left * Vector3.Dot(Vector3.forward, hitPoint) * 100);
                
                //transform.LookAt(hitPoint);

            }

        }
	}

    void OnCollisionEnter(Collision theObject)
    {
        Instantiate(sparks, theObject.contacts[0].point, Quaternion.identity);

        if(theObject.gameObject.tag == "Player")
        {
            myScore++;
            myText.text = "["+myScore+"]";
        }
    }
}
