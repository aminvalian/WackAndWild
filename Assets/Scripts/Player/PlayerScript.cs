using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject spine; //for rotation when shooting
    public GameObject gun; // 

    public int gunType; // for animation
    
    public Animator anim; 
    public MainScript engine;
    public int grenadeCount; 
    public int grenadeObject; 
    public GameObject grenadeTarget; 

	// Use this for initialization
	void Start () {

        engine = GameObject.Find("Engine").GetComponent<MainScript>();
        anim = GetComponent<Animator>();
        anim.SetInteger("gun", gunType);

    }

    // Update is called once per frame
    void Update () {
        bool shooted = false;
        Vector3 inputPos = Vector3.zero;
        anim.speed = engine.gameSpeed;

        //spine rotation
        float x = Input.mousePosition.x - (Screen.width / 2);
        spine.transform.localEulerAngles = new Vector3((x) / (Screen.width / 2) * -50, 0, 0);
	
        // keyboard inputs for drawing gun in case for animation creation
        if(Input.GetKeyDown (KeyCode.A))
        {
            anim.SetBool("draw", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("draw", false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetInteger("gun",1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetInteger("gun", 2);
        }
#if UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                    shooted = true;
                inputPos = touch.position;
            }
        }
#endif
#if UNITY_IOS
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                    shooted = true;
                inputPos = touch.position;
            }
        }
#endif
#if UNITY_WIN
       if(Input.GetMouseButtonDown(0)){
        shooted = true;
        inputPos = Input.mousePosition
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)){
            shooted = true;
            inputPos = Input.mousePosition;
        }
#endif
        if (shooted  && anim.GetCurrentAnimatorStateInfo(0).IsName("Gun"+gunType+"Idle") )
        {
            shoot(inputPos);

        }

    }

    public void shoot(Vector3 inputPos)
    {

        RaycastHit[] hit = (Physics.RaycastAll(Camera.main.ScreenPointToRay(inputPos)));
        for (int i = 0; i < hit.Length;i++)//int i = hit.Length-1; i >=0; i--)
        {
            if (hit[i].collider.gameObject.layer == 11 || hit[i].collider.gameObject.layer == 13)
            {
                if (hit.Length+""+hit[i].collider != null)
                {
                    Debug.Log(hit[i].collider.tag);
                    if(hit[i].collider.tag == "Wood")
                    {
                        //create wood shot smoke
                        i = hit.Length;
                    }
                    else if (hit[i].collider.GetComponentInParent<VillainScript>() != null)
                    {
                        gun.GetComponentInChildren<GunScript>().shoot(hit[i].collider.tag, hit[i].collider);
                        anim.SetTrigger("shoot");
                        //i = -1;
                    }
                }
            }
        }
    }

    public IEnumerator ThrowBomb(GameObject target)
    {
        grenadeTarget = target;
        anim.SetBool("draw", false);
        while (true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetTrigger("throw");
                break;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }

        }
    }
    
}
