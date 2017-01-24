using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
    public float damage;  // damage depends on gun type (power)
    public GameObject smoke;
    public GameObject tip;
    public Transform shooter;
    public bool isVillain; //if villain owns this gun
    public MainScript engine;
	// Use this for initialization
	void Start () {
        if(shooter == null)
        {
            engine = GameObject.Find("Engine").GetComponent<MainScript>();
            shooter = GameObject.FindGameObjectWithTag("Cowboy").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void shoot(string tag, Collider target)
    {
        GameObject s =  Instantiate(smoke, tip.transform.position, Quaternion.identity)as GameObject;
        
        s.transform.eulerAngles = new Vector3(0, shooter.eulerAngles.y, 0);

        s.transform.SetParent(GameObject.FindGameObjectWithTag("Ground").transform);
        if (!isVillain)
        {
            switch (tag)
            {
                case "Head":
                    target.GetComponentInParent<VillainScript>().DeliverDamage(damage, 0);
                    break;
                case "LeftChest":
                    target.GetComponentInParent<VillainScript>().DeliverDamage(damage, 1);
                    break;
                case "RightChest":
                    target.GetComponentInParent<VillainScript>().DeliverDamage(damage, 2);
                    break;
                case "RightLeg":
                    target.GetComponentInParent<VillainScript>().DeliverDamage(damage, 3);
                    break;

            }

        }
    }
}
