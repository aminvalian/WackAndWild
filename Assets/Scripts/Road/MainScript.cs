using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

    public float gameSpeed;
    public bool zoomed;
    public bool gameIsOver = false;

    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (gameSpeed == 1)
                gameSpeed = 0.25f;
            else
                gameSpeed = 1;
        }
	}
}
