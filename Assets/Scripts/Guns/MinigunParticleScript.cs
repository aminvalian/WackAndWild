using UnityEngine;
using System.Collections;

public class MinigunParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnParticleCollision(GameObject other)
    {
        if (other.GetComponentInParent<VillainScript>().alive) {
            switch (other.tag)
            {
                case "Head":
                    other.GetComponentInParent<VillainScript>().kill(0);
                    break;
                case "LeftChest":
                    other.GetComponentInParent<VillainScript>().kill(1);
                    break;
                case "RightChest":
                    other.GetComponentInParent<VillainScript>().kill(2);
                    break;
                case "RightLeg":
                    other.GetComponentInParent<VillainScript>().kill(3);
                    break;
            }
        }
    }
}
