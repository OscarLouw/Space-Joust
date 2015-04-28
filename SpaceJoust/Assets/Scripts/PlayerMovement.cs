using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private int actions;
	public int maxActions = 4;

    public float speed = 2000f;
    public float boostSpeed = 10000f;
	public MeshRenderer[] spheres;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode dash = KeyCode.LeftShift;

    private Rigidbody rigidbody;
    public Rigidbody sword;

    private float invincibleTimer = 0f;
	private float actionTimer = 1f;

	// Use this for initialization
	void Start () {
		actions = maxActions;
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (actions >= 4) {
			spheres [0].enabled = true;
			spheres [1].enabled = true;
			spheres [2].enabled = true;
			spheres [3].enabled = true;
		} else if (actions == 3) {
			spheres [0].enabled = false;
			spheres [1].enabled = true;
			spheres [2].enabled = true;
			spheres [3].enabled = true;
		} else if (actions == 2) {
			spheres [0].enabled = false;
			spheres [1].enabled = false;
			spheres [2].enabled = true;
			spheres [3].enabled = true;
		} else if (actions == 1) {
			spheres [0].enabled = false;
			spheres [1].enabled = false;
			spheres [2].enabled = false;
			spheres [3].enabled = true;
		} else {
			spheres[0].enabled = false;
			spheres[1].enabled = false;
			spheres[2].enabled = false;
			spheres[3].enabled = false;
		}

		actionTimer -= Time.deltaTime;
		if (actionTimer <= 0) {
			actionTimer = 1f;
			if(actions <= maxActions)
				actions++;
			Debug.Log(actions);
		}

        if (Input.GetKeyDown(dash) && rigidbody.velocity.magnitude > 1f && actions > 0)
        {
			actionTimer = 1f;
			actions--;
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
