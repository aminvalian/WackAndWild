using UnityEngine;
using System.Collections;

public class ObjectLocalPosition : MonoBehaviour {

    public string nameTag;

    public Vector3 LocalPosition;

	// Use this for initialization
	void Start () {
        if (nameTag != null)
        {
            GameObject g = GameObject.FindGameObjectWithTag(nameTag);
            if (g)
            {
                g.transform.localPosition = LocalPosition;
            }
        }
        else
        {
            transform.localPosition = LocalPosition;
        }
        
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        
	}

    

}
