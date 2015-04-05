using UnityEngine;
using System.Collections;

public class MultiplayerCameraController : MonoBehaviour {

    public Transform player1;
    public Transform player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 midPoint = player1.position + (player2.position - player1.position) / 2f;
        transform.position += (new Vector3(midPoint.x, 0, midPoint.z) - new Vector3(transform.position.x, 0, transform.position.z)) / Time.deltaTime * 0.02f;

        GetComponent<Camera>().fieldOfView = 45 + (player2.position - player1.position).magnitude;
	}
}
