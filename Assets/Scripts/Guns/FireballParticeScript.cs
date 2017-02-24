using UnityEngine;
using System.Collections;

public class FireballParticeScript : MonoBehaviour {

    public GameObject explosion;

    // Use this for initialization
    void Start()
    {

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

    }
    // be khoda age yadam bashe ino az kojam dar avordam !!!!! but instanciates explosion when fire ball collides with ground
    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];
        int safeLength = GetComponent<ParticleSystem>().GetSafeCollisionEventSize();
        if (collisionEvents.Length < safeLength)
            collisionEvents = new ParticleCollisionEvent[safeLength];
        int numCollisionEvents = GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while (i < numCollisionEvents)
        {
            Vector3 collisionHitLoc = collisionEvents[i].intersection;
            Instantiate(explosion, collisionHitLoc, Quaternion.identity);
            i++;
        }
    }
}
