using UnityEngine;
using System.Collections;

public class BallThrow : MonoBehaviour {

	public Rigidbody core;
	public Collider ballCollider;
	public Collider playerCollider;

	bool ballOut = false;

	// Use this for initialization
	void Start () {
		core.transform.position = Vector3.up * 100;
		Physics.IgnoreCollision (ballCollider, playerCollider);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			if(!ballOut)
			{
				core.velocity = Vector3.zero;
				core.transform.position = Camera.main.transform.position;
				core.AddForce(Camera.main.transform.forward * 1000);
				ballOut = true;
			} else {
				core.transform.position = Vector3.up * 100;
				ballOut = false;
			}

		}

		if (Input.GetMouseButtonDown (1)) {
			if(ballOut)
			{
				transform.position = core.transform.position;
				core.transform.position = Vector3.up * 100;
				ballOut = false;
			}
		}

	}
}
