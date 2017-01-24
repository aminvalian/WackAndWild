using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MaterialApplier : MonoBehaviour {

    public string prefName;
    
    public List<Material> mat = new List<Material>();
    public List<GameObject> parts = new List<GameObject>();

	// Use this for initialization
	void Start () {
	for(int i = 0; i < parts.Count; i++)
        {
            parts[i].GetComponent<Renderer>().material = mat[PlayerPrefs.GetInt(prefName,0)];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
