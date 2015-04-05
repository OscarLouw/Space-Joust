using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2000f;
    public float boostSpeed = 10000f;

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode dash = KeyCode.LeftShift;

    private Rigidbody rigidbody;
    public Rigidbody sword;

    private float invincibleTimer = 0f;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(dash) && rigidbody.velocity.magnitude > 1f)
        {
            
            invincibleTimer = 0.5f;
            rigidbody.detectCollisions = false;
            sword.detectCollisions = false;
            rigidbody.AddForce(rigidbody.velocity * boostSpeed);
            GetComponent<TrailRenderer>().time = 0.2f;
        }

        if (invincibleTimer>0)
        {
            invincibleTimer -= Time.deltaTime;
        }
        else
        {
            GetComponent<TrailRenderer>().time = 0;
            rigidbody.detectCollisions = true;
            sword.detectCollisions = true;
        }


        if (Input.GetKey(left))
        {
            rigidbody.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(right))
        {
            rigidbody.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(up))
        {
            rigidbody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(down))
        {
            rigidbody.AddForce(Vector3.back * speed);
        }



	}
}
