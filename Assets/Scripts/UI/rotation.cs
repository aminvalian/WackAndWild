﻿using UnityEngine;
using System.Collections;


public class rotation : MonoBehaviour {
    public int speed;
	// Use this for initialization
	void Start () {
       // StartCoroutine(rotate());
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + speed, transform.eulerAngles.z);

    }
    public IEnumerator rotate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
        }
    }
}
