using UnityEngine;
using System.Collections;

public class CameraLayOver : MonoBehaviour {

    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        
	}
	
	// Update is called once per frame
	void Update () {
        float m = cam.fieldOfView / 30;
        transform.localScale = new Vector3(m, m, m);
	}
    
}
