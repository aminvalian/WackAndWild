using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigatorScript : MonoBehaviour {
    public List<Transform> navPoints = new List<Transform>();
    public GameObject navigator;
    public GameObject[] horses;
    public GameObject carriageObject;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        if (navPoints.Count > 1)
        {
            navigator.transform.LookAt(navPoints[0], Vector3.up);
            if (Vector3.Distance(navPoints[1].position, navigator.transform.position) < Vector3.Distance(navPoints[0].position, navPoints[1].position))
            {
                navPoints.RemoveAt(0);
            }
            else
            {
                float fAngle = navigator.transform.eulerAngles.y;
                float diffAngle = fAngle - transform.eulerAngles.y;
                if ( diffAngle > 180)
                {
                    diffAngle -= 360;
                }
                else if(diffAngle < -180)
                {
                    diffAngle += 360;
                }

                /*if (diffAngle != 0)
                {
                    float horseAngle = horses[0].transform.localEulerAngles.z;
                    if (horseAngle > 180)
                        horseAngle -= 360;

                    float horsediff = horseAngle - (diffAngle / -5);
                    float horseAddAmount = 0.1f*(horsediff/Mathf.Abs(horsediff));
                    if (Mathf.Abs(horsediff) < 0.1f)
                    {
                        horseAddAmount = horsediff;
                    }

                    for (int i = 0; i < horses.Length; i++)
                    {

                        horses[i].transform.localEulerAngles = new Vector3(0, 0, horses[i].transform.localEulerAngles.x - (horseAddAmount * 15f));
                    }
                    
                    carriageObject.transform.localEulerAngles = new Vector3(0 , 0, carriageObject.transform.localEulerAngles.z+(horseAddAmount));
                }
                if (fAngle > 180)
                    fAngle = 360 - fAngle;*/
                //Debug.Log("f:" + fAngle + " , d:" + diffAngle +" ,angle:"+transform.eulerAngles.y+ " , add:" + ((1 / Vector3.Distance(transform.position, navPoints[0].position)) * diffAngle * 0.1f));
                if (0.5f < Mathf.Abs(diffAngle))
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + ((1 / Vector3.Distance(transform.position, navPoints[0].position)) * diffAngle * 0.1f*carriageObject.GetComponentInParent<CarriageScript>().speed), transform.eulerAngles.z);
                }
                else
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + diffAngle, transform.eulerAngles.z);

                }
            }
        }

    }
}
