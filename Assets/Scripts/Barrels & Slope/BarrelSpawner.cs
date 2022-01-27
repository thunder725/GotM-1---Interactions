using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] GameObject barrelPrefab;
    [SerializeField] float minSpawnCooldown, maxSpawnCooldown, movementAmplitude, movementSpeed;
    float currentSpawnCooldown, currentMovementSpeed, currentMaxSpawnCooldown, movementDirection;
    
    [Header("Timer Shenanigans")]
    [SerializeField] float timerToSpeedRatio;
    [SerializeField] float timerToSpawnCooldownRatio, maxSpeed, minMaxSpawnCooldown;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        movementDirection = 1;
        currentMovementSpeed = movementSpeed;
        currentMaxSpawnCooldown = maxSpawnCooldown;
    }


    void Update()
    {
        // Slowly ramp up the difficulty by increasing movement speed and decreasing the "random spawn cap" value, until a max is reached
        if (currentMovementSpeed < maxSpeed)
        {currentMovementSpeed = Mathf.Min(movementSpeed + (Time.timeSinceLevelLoad * timerToSpeedRatio), maxSpeed);}
        if (currentMaxSpawnCooldown > minMaxSpawnCooldown)
        {currentMaxSpawnCooldown = Mathf.Max(maxSpawnCooldown + (Time.timeSinceLevelLoad * timerToSpawnCooldownRatio), minMaxSpawnCooldown);}

        // Stop spawning AND moving is player dead to avoid lagging more than necessary
        if (!GameManager.isPlayerDead)
        {
            currentSpawnCooldown -= Time.deltaTime;

            if (Mathf.Abs(transform.position.x - startPos.x) > movementAmplitude)
            {
                movementDirection = -movementDirection;
            }

            // Starting at the base position and sliding from left to right in cycles with an amplitude
            // It's hard to explain but I can't use a mathf.Cos because it prevents the positon to have +=
            // Which changes the "visible speed" when the cap is met... it's weird but trust me I tested it
            transform.position += new Vector3(movementDirection * currentMovementSpeed * Time.fixedDeltaTime, 0, 0);


            // Old code with the cos that bugged, try it yourself you'll see the speed change when the speed meets its cap
            // transform.position = new Vector3(startPos.x + (Mathf.Cos(Time.timeSinceLevelLoaded * currentMovementSpeed) * movementAmplitude), startPos.y, startPos.z);
        }

        

        if (currentSpawnCooldown <= 0)
        {
            SpawnBarrel();
            currentSpawnCooldown = Random.Range(minSpawnCooldown, currentMaxSpawnCooldown);
        }
    }

    void SpawnBarrel()
    {
        Instantiate(barrelPrefab, transform.position, Quaternion.Euler(0, 90, 0));
    }


}
