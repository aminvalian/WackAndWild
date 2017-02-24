using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour
{
    public MainScript engine;

    public GameObject carriage;
    public Vector3 initPosition;
    public Vector3 initAngles;

    public Animator anim;
    public PlayerScript player;

    public float timer = 0;



    // Use this for initialization
    void Start()
    {
        
        engine = GameObject.Find("Engine").GetComponent<MainScript>();
        player = carriage.GetComponentInChildren<PlayerScript>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;        
        
    }

    public void ZoomIn()
    {
        player.anim.SetBool("draw", true);
        engine.gameSpeed = 0.25f;
        anim.SetBool("zoomed", true);
        engine.zoomed = true;
        timer = 8;


    }
    public void ZoomOut()
    {
        
        player.anim.SetBool("draw", false);
        engine.zoomed = false;
        engine.gameSpeed = 1;
        timer = 0;
        anim.SetBool("zoomed", false);
        engine.GetComponent<RoadScroller>().passedTrip++;
        if (engine.GetComponent<RoadScroller>().passedTrip == engine.GetComponent<RoadScroller>().totalTrip)
        {
            ClearVillains();
        }
    }

    public void CheckVillains(List<VillainScript> men)
    {
        bool a = true;
        for (int i = 0; i < men.Count; i++)
        {

            if (men[i].alive)
            {
                a = false;
            }

        }
        if ((a || timer <= 0) && anim.GetBool("zoomed") == true)
        {
            ZoomOut();

            for (int i = 0; i < men.Count; i++)
            {
               
            }
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
