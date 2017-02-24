using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CarriageScript : MonoBehaviour
{

    public float speed;
    private GameObject cam;

    public List<GameObject> wheels = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        cam = GameObject.Find("Main Camera");

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // navigating
        

        //rotating wheels
        for (int i = 0; i < wheels.Count; i++)
        {
            wheels[i].transform.Rotate(Vector3.forward,speed*5);

        }
        if(transform.eulerAngles.y >= 90)
        {
        }
    }

    public IEnumerator TurnRight(GameObject des)
    {
    while (Vector3.Distance(transform.position, des.transform.position) > 1)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0.29f*speed, transform.eulerAngles.z);
            yield return new WaitForSeconds(1 / 50);
            Debug.Log("Dis: "+Vector3.Distance(transform.position, des.transform.position));
            Debug.Log("A: "+transform.eulerAngles.y);

        }

        Debug.Log("a");
        transform.localEulerAngles = new Vector3(0, 90, 0);
        cam.GetComponent<Animator>().enabled = true;

    }
    public IEnumerator TurnLeft(GameObject des)
    {

        while (Vector3.Distance(transform.position, des.transform.position) > 1)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 0.29f * speed, transform.eulerAngles.z);
            yield return new WaitForSeconds(1/50);
            Debug.Log("Dis: " + Vector3.Distance(transform.position, des.transform.position));
            Debug.Log("A: " + transform.eulerAngles.y);

        }

        Debug.Log("a");
        transform.localEulerAngles = new Vector3(0, 0, 0);
        cam.GetComponent<Animator>().enabled = true;

    }


}
