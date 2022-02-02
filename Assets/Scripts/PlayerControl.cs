using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{    
    [Header("Stats & Numbers")]
    public float shockwaveCooldown;
    [SerializeField] float movementSpeed, maxSpeed, shockwaveRadius, shockwaveStrength, shockwaveRotationStrength, movementRotation;

    [HideInInspector] public float currentShockwaveCooldown;
    [SerializeField] bool limitFPS;
    bool isShockwaveReady;
    float baseRigidbodyDrag, currentSlipperyMovementTimer;

    [Header("Scripts Assignations")]

    [SerializeField] ShockwaveUI shockwaveUI;
    [SerializeField] GameObject shockwaveParticles, deathParticles, slipperyParticles;
    PlayerControlInputs inputs;
    [SerializeField] LayerMask barrelMask;
    [SerializeField] HighScoreManager hsm;
        [SerializeField] AudioSource explosionSound;


    Rigidbody rb;

    
    void Awake()
    {
        inputs = new PlayerControlInputs();
        rb = GetComponent<Rigidbody>();

        // Cuz why not?
        Application.targetFrameRate = limitFPS? 60 : -1;
    }
    void Start()
    {
        baseRigidbodyDrag = rb.drag;
    }
    void OnEnable() // The classic double OnEnableDisable when using the new input system
    {   inputs.Enable();
        inputs.Default.SpecialOne.started += Shockwave; 
        inputs.Default.RestoreShockwave.started += RestoreShockwave; }
    void OnDisable()
    {   inputs.Disable();
        inputs.Default.SpecialOne.started -= Shockwave; 
        inputs.Default.RestoreShockwave.started -= RestoreShockwave; }

    void FixedUpdate()
    {
        // Read the values
        Vector2 movementInput = inputs.Default.Movement.ReadValue<Vector2>().normalized;


        if (movementInput.magnitude != 0)
        {
            // Transform the Vector2 values into a Vector3 since I don't want "up" to be upwards but to be forward;
            // I put it outside of the "check if magnitude != 0" to allow for the self-rotation with movement
            Vector3 movementValues = new Vector3(movementInput.x, 0, movementInput.y);

            rb.AddForce(movementValues * movementSpeed);

            // Prevent going too fast
            // It might actually never be used due to the movement speed and the size of the arena, but just it case
            Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
            
        }
        RotateWithMovement(rb.velocity);

    }

    void Update()
    {
        if (!isShockwaveReady)
        { 
            currentShockwaveCooldown -= Time.deltaTime;

            if (currentShockwaveCooldown <= 0)
            {
                shockwaveUI.shockwaveFilled();
                isShockwaveReady = true;
            }
        }
        if (currentSlipperyMovementTimer >= 0)
        {
            rb.drag = 0;
            currentSlipperyMovementTimer -= Time.deltaTime;
            if (currentSlipperyMovementTimer <= 0)
            {
                rb.drag = baseRigidbodyDrag;
            }
        }
        
    }

    void Shockwave(InputAction.CallbackContext c)
    {
        if (currentShockwaveCooldown > 0)
        {return;}

        explosionSound.Play();
        Instantiate(shockwaveParticles, transform.position + new Vector3(0,1,0), Quaternion.identity);

        currentShockwaveCooldown = shockwaveCooldown;
        isShockwaveReady = false;
        shockwaveUI.ShockwaveUsed();

        Collider[] hits = Physics.OverlapSphere(transform.position, shockwaveRadius, barrelMask);
        if (hits.Length != 0)
        {
            // FUS ROH DA
            foreach(Collider _c in hits)
            {
                // Debug.Log("found");
                
                Vector3 toPlayer = (_c.transform.position - transform.position).normalized;

                // I'm adding a Vector3.up to make them go upwards even if they are almost horizontal relative to the player 
                Vector3 directionToBarrel = (toPlayer + Vector3.up).normalized;
                // This is so it's funnier to look at
                _c.attachedRigidbody.constraints = RigidbodyConstraints.None;
                _c.attachedRigidbody.mass = .4f;
                _c.transform.Rotate(- toPlayer * shockwaveRotationStrength);
                _c.attachedRigidbody.AddForce(directionToBarrel * shockwaveStrength);
            }
        }
    }

    void RotateWithMovement(Vector3 currentMovement)
    {
        // The CurrentMovement is the velocity of the rigidbody, so I need to divide with a high value because it can fluctuate from 0 to 25 (and negatives too)
        float angleX = 0;
        float angleZ = 0;

        if (currentMovement.x != 0) // Move +X rotate -Z
        {
            float angleMult = currentMovement.x / 13;
            angleZ = movementRotation * -angleMult;
        }
        if (currentMovement.z != 0) // Move +Z rotate +X
        {
            float angleMult = currentMovement.z / 13;
            angleX = movementRotation * angleMult;
        }

        transform.rotation = Quaternion.Euler(angleX, 0, angleZ);

    }


    public void Death()
    {
        Debug.Log("I DED");
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        hsm.StopTimer();
        GameManager.isPlayerDead = true;
        Destroy(gameObject);
    }


    void RestoreShockwave(InputAction.CallbackContext c)
    {
        if (!GameManager.isDebugModOn)
        {return;}

        currentShockwaveCooldown = 0;
        shockwaveUI.shockwaveFilled();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirePillar")
        {
            Death();
        }
    }

    public void EnableSlipperyGround(float time)
    {
        Instantiate(slipperyParticles, transform);
        currentSlipperyMovementTimer = time;
    }

    // private void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;

    //     Gizmos.DrawWireSphere(transform.position, shockwaveRadius);
    // }

}
