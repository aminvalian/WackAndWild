using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public MainScript engine;

    public GameObject carriage;
    public Vector3 initPosition;
    public Vector3 initAngles;

    public Animator anim;
    public PlayerScript player;



    // Use this for initialization
    void Start()
    {
        
        engine = GameObject.Find("Engine").GetComponent<MainScript>();
        player = carriage.GetComponentInChildren<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void ZoomIn()
    {
        player.anim.SetBool("draw", true);
        anim.SetBool("zoomed", true);
        engine.zoomed = true;
    }
    public void ZoomOut()
    {
        
        player.anim.SetBool("draw", false);
        engine.zoomed = false;
        anim.SetBool("zoomed", false);
        engine.GetComponent<RoadScroller>().passedTrip++;
        if (engine.GetComponent<RoadScroller>().passedTrip == engine.GetComponent<RoadScroller>().totalTrip)
        {
            ClearVillains();
        }
    }

    public void CheckVillains()
    {
        bool a = false;
        GameObject[] villains = GameObject.FindGameObjectsWithTag("Villain");
        for(int i = 0;i<villains.Length; i++)
        {
            if(Vector3.Distance( villains[i].transform.position, carriage.transform.position) < 45 && villains[i].GetComponent<VillainScript>().alive && villains[i].transform.position.x+villains[i].transform.position.z>5)
            {
                a = true;
                break;
            }
        }
        if (!a && anim.GetBool("zoomed") == true)
        {
            ZoomOut();
        }

    }

    public void ClearVillains()
    {

        GameObject[] v = GameObject.FindGameObjectsWithTag("Villain");
        for (int i = 0; i < v.Length; i++)
        {
            Destroy(v[i]);
            engine.gameIsOver = true;
        }
    }
}
