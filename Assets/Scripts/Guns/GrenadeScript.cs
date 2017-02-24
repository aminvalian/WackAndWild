using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {

    public bool active;
    public Vector3 destination;
    public PlayerScript player;
    private Rigidbody rigid;
    public GameObject explosion;

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Cowboy").GetComponent<PlayerScript>();
    }

    void OnDisable()
    {
        if (!active)
        {
            GameObject g = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
            g.GetComponent<GrenadeScript>().active = true;
            //g.GetComponent<Rigidbody>().velocity = destination * 3;
            GameObject.FindGameObjectWithTag("Cowboy").GetComponent<PlayerScript>().anim.SetBool("draw", true);
            //add tourqe
        }

    }

	// FixedUpdate is called once per frame
	void FixedUpdate () {
        if (active)
        {
            GetComponent<Rigidbody>().velocity = (player.grenadeTarget.transform.position - transform.position)*5; 
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ground")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
