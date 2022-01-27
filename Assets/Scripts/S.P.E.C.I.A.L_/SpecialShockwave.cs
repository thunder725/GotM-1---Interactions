using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShockwave : MonoBehaviour
{
    [SerializeField] float shockwaveRadius, shockwaveStrength, shockwaveRotationStrength;
    [SerializeField] LayerMask barrelMask;


    void Start()
    {
        Destroy(gameObject, 2f);

        // Long live copy-pasted code!!

        Collider[] hits = Physics.OverlapSphere(transform.position, shockwaveRadius, barrelMask);
        if (hits.Length != 0)
        {
            // FUS ROH DA
            foreach(Collider _c in hits)
            {
                Vector3 toEpicenter = (_c.transform.position - transform.position).normalized;

                // I'm adding a Vector3.up to make them go upwards even if they are almost horizontal relative to the player 
                Vector3 directionToBarrel = (toEpicenter + Vector3.up).normalized;
                // This is so it's funnier to look at
                _c.attachedRigidbody.constraints = RigidbodyConstraints.None;
                _c.attachedRigidbody.mass = .4f;
                _c.transform.Rotate(- toEpicenter * shockwaveRotationStrength);
                _c.attachedRigidbody.AddForce(directionToBarrel * shockwaveStrength);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shockwaveRadius);
    }
}

