using UnityEngine;
using System.Collections;

public class GrenadeIconScript : MonoBehaviour {

    public PlayerScript player;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Cowboy").GetComponent<PlayerScript>();
    }


    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Vector3 inputPos = Vector3.zero;
#if UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                inputPos = touch.position;
            }
        }
#endif
#if UNITY_IOS
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                inputPos = touch.position;
            }
        }
#endif
#if UNITY_WIN
       if(Input.GetMouseButtonDown(0)){
        inputPos = Input.mousePosition
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            inputPos = Input.mousePosition;
        }
#endif

        RaycastHit[] hit = (Physics.RaycastAll(Camera.main.ScreenPointToRay(inputPos)));
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.gameObject.layer == 5)
            {
                if (hit[i].collider != null)
                {
                    if (hit[i].collider == GetComponent<SphereCollider>())
                    {
                        Debug.Log("bomb Icon clicked");
                        StartCoroutine( player.ThrowBomb(this.gameObject));

                    }
                }
            }
        }
    }
}
