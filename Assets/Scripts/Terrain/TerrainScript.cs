using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainScript : MonoBehaviour {

    public int type;
    public RoadScroller road;
    public GameObject villains;
    public GameObject covers;
    public bool consistent = false;
    public bool containsVillain;
    public List<Transform> navPoints = new List<Transform>();
    

    // Use this for initialization
    void Start()
    {
        if (!containsVillain && villains!= null)
        {
            Destroy(villains);
            Destroy(covers);
        }
        road = GameObject.Find("Engine").GetComponent<RoadScroller>();
        if (!consistent)
        {
            Locate();

            for (int i = 0; i < navPoints.Count; i++)
            {
                road.carriage.GetComponent<NavigatorScript>().navPoints.Add(navPoints[i]);
            }
        }
        
    }

    public void Locate()
    {
        //finds terrain location according to it's type
        if (type == 0 || type == 2 )
        {
            
                transform.position = new Vector3(road.inGameTerrains[road.inGameTerrains.Count - 2].transform.position.x, 0, road.inGameTerrains[road.inGameTerrains.Count - 2].transform.position.z+35f);
            
        }
        if (type == 1 || type == 3)
        {

            transform.position = new Vector3(road.inGameTerrains[road.inGameTerrains.Count - 2].transform.position.x+ 35f, 0, road.inGameTerrains[road.inGameTerrains.Count - 2].transform.position.z);

        }
    }


    // Update is called once per frame
    void Update () {
	}
}
