using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadScroller : MonoBehaviour {

    public MainScript main;
    public CarriageScript carriage;
    public GameObject carriageObject;
    public GameObject horseObject;
    public HorseScript horse;

    public List<GameObject> terrains = new List<GameObject>();
    public List<GameObject> inGameTerrains = new List<GameObject>();
    public List<int> nextTerrains ;
    public int totalTrip;
    public int passedTrip;

	// Use this for initialization
	void Start () {
        carriage = carriageObject.GetComponent<CarriageScript>();

        // instanciates first 5 terrains and first created terrain (terrain #0) will be the parent of terrain #1, terrain #1 is the parent
        // of terrain #2 and so on                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        for (int i = 0; i <5; i++)
        {
            GameObject g = Instantiate(terrains[0], new Vector3(0, 0, (i) * 35f), Quaternion.identity) as GameObject;
            inGameTerrains.Add(g);
            g.GetComponent<TerrainScript>().consistent = true;
            if (i > 0)
            {
                g.transform.SetParent(inGameTerrains[inGameTerrains.Count - 2].transform);
                if(i> 1)
                {
                    g.GetComponent<TerrainScript>().containsVillain = true;
                }
            }
        }
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate() {

	    // rotates all terrains according to carriage angle
        inGameTerrains[0].transform.position = new Vector3(inGameTerrains[0].transform.position.x - 0.05f *carriage.speed* main.gameSpeed* Mathf.Sin(Mathf.Deg2Rad * carriageObject.transform.eulerAngles.y) , inGameTerrains[0].transform.position.y, inGameTerrains[0].transform.position.z - 0.05f * carriage.speed* main.gameSpeed * Mathf.Cos(Mathf.Deg2Rad * carriageObject.transform.eulerAngles.y));
            
        // if terrain 0 is behind the player terrain 1 will become the new parrent. terrain 0 will be deleted
        if (inGameTerrains[0].transform.position.z + inGameTerrains[0].transform.position.x < -40)
        {
            if(nextTerrains.Count == 0)
            {
                nextTerrains.Add(inGameTerrains[inGameTerrains.Count - 1].GetComponent<TerrainScript>().type);
            }
            GameObject g = Instantiate(terrains[nextTerrains[0]]) as GameObject;
            
           
            nextTerrains.RemoveAt(0);
            //if game is not over and last terrain does not have villain and it is not right after a turn 
            if (inGameTerrains[inGameTerrains.Count - 1].GetComponent<TerrainScript>().type<2 && !main.gameIsOver)
            
            {
                g.GetComponent<TerrainScript>().containsVillain = true;
                float r = Random.Range(0, 10);
                if (r < 4)
                {
                    GenerateTurn();
                    Debug.Log(r);
                }
            }
            
            inGameTerrains.Add(g);
            g.transform.SetParent(inGameTerrains[inGameTerrains.Count - 2].transform);
            inGameTerrains[1].transform.SetParent(null);
            Destroy(inGameTerrains[0].gameObject);
            inGameTerrains.RemoveAt(0);
        }
        
    }

    public void GenerateTurn()
    {
        Debug.Log("turn");
        if(nextTerrains.Count == 0)
        {
            nextTerrains.Add(inGameTerrains[inGameTerrains.Count - 1].GetComponent<TerrainScript>().type);
        }
        if (nextTerrains.Count  <= 6)
        {
            // if right turn gives 3 terrains space before next turn
            if (nextTerrains[nextTerrains.Count - 1] == 0)
            {
                nextTerrains.Add(2);
                nextTerrains.Add(1);
                nextTerrains.Add(1);
                nextTerrains.Add(1);
            }
            else
            {
                nextTerrains.Add(3);
                nextTerrains.Add(0);
                nextTerrains.Add(0);
                nextTerrains.Add(0);
            }
        }
    }
    
}
