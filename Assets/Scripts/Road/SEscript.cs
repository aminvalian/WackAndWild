using UnityEngine;
using System.Collections;

public class SEscript : MonoBehaviour {
    public float seconds;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, seconds);
        transform.parent = GameObject.Find("Engine").GetComponent<RoadScroller>().inGameTerrains[0].transform;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
	
	}
}
