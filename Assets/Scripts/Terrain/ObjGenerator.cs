using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjGenerator : MonoBehaviour {

    public Transform p;
    public bool randomAngle;
    public bool keepParent;

    public List<GameObject> objs = new List<GameObject>();
    

	// Use this for initialization
	void Start () {
        int r = Random.Range(0, objs.Count);
        if (objs[r] != null)
        {
            Quaternion q;
            if (randomAngle)
                q = Quaternion.Euler(0, Random.Range(0, 359), 0);
            else
                q = Quaternion.identity;
            GameObject g = Instantiate(objs[r], transform.position, q) as GameObject;
            g.transform.SetParent(p);
            
        }
        if(!keepParent)
            Destroy(gameObject, 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
