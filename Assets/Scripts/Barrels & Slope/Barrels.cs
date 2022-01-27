using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    // Push should be positive on Y and negative on Z, so I'll do -pushZ in the method 
    [SerializeField] float minPushY, maxPushY, minPushZ, maxPushZ;
    
    // Limit recieving only one push per frame, because of the way they're randomly placed, the barrels
    // might touch 1 to 4 panels each time they touch the slope, which makes balancing the pushes' values
    // too difficult, so I'm capping it at one
    int pushesThisFrame;
    Rigidbody rb;
    MeshRenderer ren;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ren = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Reset this number each frame
        if (pushesThisFrame != 0)
        {pushesThisFrame = 0;}

        // I access the renderer to check if it's visible on camera or not
        // If it's out of camera, no need to keep it away unless it's above the player 
        // (it could fall back on him as a surprise), if it's under 0y just remove it
        if (!ren.isVisible && transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, 0, -.3f)); //To prevent barrels clogging up the platform in the bottom
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        switch (collisionInfo.gameObject.tag)
        {
            case "Slope":
            if (pushesThisFrame == 0)
            {
                pushesThisFrame ++;

                // Give it a little push, without it it would just roll slowly instead of bouncing
                // Does this count as an object-to-object interaction?
                float pushY = Random.Range(minPushY, maxPushY);
                float pushZ = Random.Range(minPushZ, maxPushZ);

                Vector3 directionPush = new Vector3(0, pushY, -pushZ);

                rb.AddForce(directionPush);
            }

            // I could just do GetComponent<>().LightUpPanel() and not store it but I might do other things with it
            // So I keep it that way just in case
            SlopePanels _script = collisionInfo.gameObject.GetComponent<SlopePanels>();
            _script.LightUpPanel();

            break;



            case "Player":
            collisionInfo.gameObject.GetComponent<PlayerControl>().Death();
            
            // Colliding with the player removes a lot of velocity, so I'll add a push to still make it feel "unstoppable"
            // But I don't care enough to make another random so just a set fraction will do the trick
            rb.AddForce(new Vector3(0, 0, -.7f * maxPushZ));

            break;
        }
    }

}
