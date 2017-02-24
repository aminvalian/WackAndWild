using UnityEngine;
using System.Collections;

public class HorseScript : MonoBehaviour {

    Animator anim;
    public MainScript engine;

    // Use this for initialization
    void Start () {
        engine = GameObject.Find("Engine").GetComponent<MainScript>();
        anim = GetComponent<Animator>();

    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        anim.speed = engine.gameSpeed;

    }


}
