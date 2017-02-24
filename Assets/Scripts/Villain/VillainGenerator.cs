using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VillainGenerator : MonoBehaviour {


    
    public bool isCaptain;
    public VillainGenerator captain;
    public List<VillainScript> men = new List<VillainScript>();
    public List<GameObject> villains = new List<GameObject>();
    public VillainScript villain;
    public List<float> times = new List<float>();

    // Use this for initialization
    void Start()
    {
        int r = Random.Range(0, villains.Count);
        if (villains[r] != null)
        {
            GameObject g = Instantiate(villains[r], transform.position, Quaternion.identity) as GameObject;
            g.transform.SetParent(null);
            villain = g.GetComponent<VillainScript>();
            
        }

        if (isCaptain)
        {
            villain.isCaptain = true;
            
        }
        else
            captain.men.Add(villain.GetComponent<VillainScript>());
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnDestroy()
    {
        
        if (isCaptain)
        {
            men.Add(villain);
            villain.men = men;
            for (int i = 0; i<men.Count; i++)
            {
                int r = Random.Range(0, times.Count);
                men[i].hiddenTime = times[r]+3;
                times.RemoveAt(r);
                men[i].men = men;
            }
        }
    }
}
