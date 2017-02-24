using UnityEngine;
using System.Collections;

public class CanonScript : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        Instantiate(explosion, GetComponent<Particle>().position,Quaternion.identity);
    }
}
