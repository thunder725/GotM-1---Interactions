using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillarSpawner : MonoBehaviour
{
    [SerializeField] GameObject firePillar;
    [SerializeField] Transform slopedGround;
    // IMPORTANT : MAX Z MUST BE PLACED AT THE HIGHEST POINT OF THE GROUND FOR THE HEIGHT CALCULATION
    // It's max Z because it's going downwards 
    // I got all of those using the "Position Checker" item in the scene, the best thing ever to find positions
    [SerializeField] float minX, maxX, minZ, maxZ, topOfSloppedGroundY;// for the position maths 
    [SerializeField] int numberOfPillars; 

    // [SerializeField] float baseTimerBetweenPillars, diminishingRatio, minCap; // The starting value between pillars, ratio for decreasing the value, and cap
    // float currentTimerBetweenPillars; // The current timer that'll decrease
    // float actualTimerBetweenPillars; // The value between pillar that will be used to restart the timer, that can lower with the ratio
    // This is all to have fire pillars spawn closer and closer together as the time advances... I didn't find a better naming scheme

    // void Start()
    // { currentTimerBetweenPillars = actualTimerBetweenPillars = baseTimerBetweenPillars; }

    // void Update()
    // {
    //     if (actualTimerBetweenPillars != minCap) // Copy-pasted code from the barrel spawner
    //     {actualTimerBetweenPillars = Mathf.Max(baseTimerBetweenPillars + (Time.timeSinceLevelLoad * diminishingRatio), minCap);} 

    //     if (!GameManager.isPlayerDead)
    //     {
    //         currentTimerBetweenPillars -= Time.deltaTime;
    //         if (currentTimerBetweenPillars <= 0)
    //         {
    //             currentTimerBetweenPillars = actualTimerBetweenPillars;
    //             SpawnFirePillar();
    //         }
    //     }
    // }

    public void SpawnFirePillars()
    {
        for (int i = 0; i < numberOfPillars; i++)
        {
            float xPos = Random.Range(minX, maxX);
            float zPos = Random.Range(minZ, maxZ);

            float yPos = findHeight(xPos, zPos);


            Instantiate (firePillar, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        }
    }

    float findHeight(float x, float z)  // The ground is slopped so I need to find the height based on the distance Z and the angle of the slope using "SIMPLE" TRIGONOMETRY (tm)
    {

        float slopeAngle = slopedGround.eulerAngles.x + 90; // The 3D Model of the ground is rotated 90 degrees so I need to adjust it to get the real angle
        float tanAngle = Mathf.Tan(-slopeAngle * Mathf.Deg2Rad); // Tan is negative because angle is something like -7, and it's in degrees but Mathf is in radians

        float displacedY = tanAngle * Mathf.Abs(maxZ - z);  // "Displaced" because it's only the distance from the highest point of the ground to the ground at the Z value
        
        return topOfSloppedGroundY + displacedY;   // this topOfSloppedGroundY is the height of the highest point of the ground
        // Which means the point from which maxZ is sampled, so I need to add it to have the absolute value from y=0
    }
}
