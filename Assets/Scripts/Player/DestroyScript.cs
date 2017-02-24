using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

    public float seconds;
    public MainScript engine;
    public Animator anim;
    float time = 0;

    // Use this for initialization
    void Start () {
        engine = GameObject.Find("Engine").GetComponent<MainScript>();
        anim = GetComponent<Animator>();
        
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        if(anim != null)
            anim.speed = engine.gameSpeed;
        time += Time.deltaTime*engine.gameSpeed;
        if (time > seconds)
            Destroy(gameObject);

    }
}
