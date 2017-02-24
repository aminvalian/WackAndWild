using UnityEngine;
using System.Collections;

public class LocalPositionAssigner : MonoBehaviour {

    public Vector3 pos;

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(pos.x,pos.y,pos.z);
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
	
	}
}
