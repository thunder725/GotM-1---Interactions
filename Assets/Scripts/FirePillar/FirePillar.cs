using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{

    float currentDuration;
    // 0 = "Warmup" / "Warning" phase, only the bottom particle is enabled
    // 1 = Pillar phase, with everything active included the hitbox
    // 2 = Finished phase, with hitbox disabled because the particles are going away (to have a smooth end instead of just deleting)

    int currentStage;

    [Header("Assignations")]
    [SerializeField] GameObject startingParticles;
    [SerializeField] GameObject pillarParticles, pillarHitbox;
    GameObject _startingParticles, _pillarParticles;


    void Start()
    {
        currentStage = 0;
        _startingParticles = Instantiate(startingParticles, transform);
        // I can access pillarParticles (a prefab) because I can
        // So the warning time is the difference between the starting particles' duration (which last the whole thing)
        // and the pillar's duration which starts after the warning time is finished until the end
        currentDuration = _startingParticles.GetComponent<ParticleSystem>().main.duration - pillarParticles.GetComponent<ParticleSystem>().main.duration;
    }


    void Update()
    {
        currentDuration -= Time.deltaTime;
        if (currentDuration <= 0)
        {
            switch (currentStage)
            {
                case 0:
                    currentStage = 1;
                    _pillarParticles = Instantiate(pillarParticles, transform);
                    currentDuration = _pillarParticles.GetComponent<ParticleSystem>().main.duration;
                    pillarHitbox.SetActive(true);
                break;

                case 1:
                    currentDuration = 1;
                    pillarHitbox.SetActive(false);
                    currentStage = 2;
                break;

                case 2:
                    Destroy(gameObject);
                    // Since the particles are instantiated I can just delete the GameObject they'll disappear too
                break;
            }
        }
    }
}
