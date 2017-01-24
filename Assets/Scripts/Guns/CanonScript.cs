using UnityEngine;
using System.Collections;

public class CanonScript : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        Instantiate(explosion, GetComponent<Particle>().position,Quaternion.identity);
    }
}
