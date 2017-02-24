using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VillainScript : MonoBehaviour {

    public int type;
    public GameObject carriage;
    public GameObject coinObject;
    public MainScript engine;
    public GunScript gun;
    public Animator anim;
    public float reloadTime;
    public float aimTime;
    public float health;
    public float hiddenTime;
    private CameraScript cam;
    public bool alive = true;
    public bool isCaptain;
    public bool isShooting = false;
    public int shootingCount;
    public List <Collider> colliders = new List<Collider>();
    public List <VillainScript> men = new List<VillainScript>();

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        engine = GameObject.Find("Engine").GetComponent<MainScript>();
        anim = GetComponent<Animator>();
        anim.SetInteger("type", type);
        anim.SetBool("hidden", true);
        carriage = engine.GetComponent<RoadScroller>().carriageObject;
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        anim.speed = engine.gameSpeed;
        transform.position = new Vector3(transform.position.x - 0.05f * carriage.GetComponent<CarriageScript>().speed * engine.gameSpeed * Mathf.Sin(Mathf.Deg2Rad * carriage.transform.eulerAngles.y), transform.position.y, transform.position.z - 0.05f * carriage.GetComponent<CarriageScript>().speed * engine.gameSpeed * Mathf.Cos(Mathf.Deg2Rad * carriage.transform.eulerAngles.y));
        if (isShooting)
        {
            hiddenTime -= Time.deltaTime ;
            if (hiddenTime <= 0)
            {
                aimTime -= Time.deltaTime;
            }
        }
        if (alive)
        {
            transform.LookAt(Vector3.zero, Vector3.up);
            if (isShooting && hiddenTime <= 0 )
            {

                anim.SetBool("hidden", false);
                if (aimTime <= 0)
                {
                    shoot();
                    aimTime = 3f;
                }
                
                
                    
                
            }
        }
        if (Vector3.Distance(transform.position, carriage.transform.position) < 20 && alive && isCaptain && !isShooting) {
            isShooting = true;
            for(int i = 0; i < men.Count; i++)
            {
                men[i].isShooting = true;
                for (int j = 0; j < colliders.Count; j++)
                {
                    men[i].colliders[j].enabled = true;
                }
            }
            for (int i = 0; i < colliders.Count; i++)
            {
                colliders[i].enabled = true;
            }
            cam.ZoomIn();
            
            carriage.GetComponentInChildren<PlayerScript>().anim.SetBool("draw", true);
        }
        if(transform.position.z + transform.position.x < 5)
        {
            cam.CheckVillains(men);
        }
        if (transform.position.x+transform.position.z <-5)
        {
            Destroy(gameObject);
        }
	}

    public void shoot()
    {
        gun.shoot(null, null);  //random damage will be dellivered to the player(not scripted yet)
        anim.SetTrigger("shoot");


    }

    public void DeliverDamage(float gunPower, int position)
    {
        float damage = 0;
        switch (position)
        {
            case 0:
                damage = 10;
                break;
            case 1:
                damage = 5;
                break;
            case 2:
                damage = 5;
                break;
            case 3:
                damage = 4;
                break;
            
        }
        //Debug.Log(damage);
        damage *= gunPower;
        if(health<= damage)
        {
            kill(position);
        }
        else
        {
            health -= damage;
        }
        //Debug.Log("h: "+health+"   d: "+ damage);

    }

    public void kill(int type)
    {
        for (int i = 0; i < Random.Range(3, 8); i++)
        {
            GameObject c = Instantiate(coinObject, new Vector3(transform.position.x,1.68f,transform.position.z), Quaternion.Euler(0,Random.Range(0,180),0)) as GameObject;
            c.transform.parent = transform;
            float f = Random.Range(250, 350);
            c.GetComponent<Rigidbody>().AddForce(Random.Range(-30,30), f, Random.Range(-30, 30));
        }
        alive = false;
        cam.CheckVillains(men);
        if (type == 0)
        {
            anim.SetInteger("deadType", Random.Range(0,4));
            anim.SetTrigger("die");
            
        }
        if (type == 1)
        {
            anim.SetInteger("deadType", 10);
            anim.SetTrigger("die");
        }
        if (type == 2)
        {
            anim.SetInteger("deadType", 20);
            anim.SetTrigger("die");
        }
        if (type == 3)
        {
            anim.SetInteger("deadType", 30);
            anim.SetTrigger("die");
        }
    }
    
}
