using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = new Vector3(target.position.x, 0, target.position.z);
        Vector3 cameraPos = new Vector3(transform.position.x, 0, transform.position.z);

        transform.position += (targetPos - cameraPos)/0.3f*Time.deltaTime;
	}
}
