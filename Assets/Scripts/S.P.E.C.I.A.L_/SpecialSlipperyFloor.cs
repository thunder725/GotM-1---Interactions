using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSlipperyFloor : MonoBehaviour
{
    public PlayerControl player;
    bool isSlippery;
    [SerializeField] float slipperyMovementTimer;
    float currentTimer;
    [SerializeField] MeshRenderer groundMeshRenderer;
    [SerializeField] Material groundSlipperyMaterial, groundDefaultMaterial;
    public void StartingSlipperySlope()
    {
        isSlippery = true;
        player.EnableSlipperyGround(slipperyMovementTimer);
        groundMeshRenderer.material = groundSlipperyMaterial;
        currentTimer = slipperyMovementTimer;
    }

    void Update()
    {
        if (isSlippery)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                isSlippery = false;
                groundMeshRenderer.material = groundDefaultMaterial;
            }
        }
    }
}
