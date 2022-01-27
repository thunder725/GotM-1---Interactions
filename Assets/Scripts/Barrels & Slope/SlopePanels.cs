using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopePanels : MonoBehaviour
{
    // Nothing hard to understand here I think, I just light up the panels when the barrel touches them
    // and turn them off after a small time has passed
    [SerializeField] Texture2D unlitTexture, litTexture, specialUnlitTexture, specialLitTexture;
    [SerializeField] float litTimer;
    [SerializeField] MeshRenderer mr;
    [SerializeField] SpecialRoulette special;
    float currentLitTimer;
    bool isSpecial;

    void Awake()
    {
        TurnOffPanel();
    }

    void Update()
    {
        if (currentLitTimer > 0)
        {
            currentLitTimer -= Time.deltaTime;
            if (currentLitTimer <= 0)
            {
                TurnOffPanel();
            }
        }
    }

    public void LightUpPanel()
    {
        currentLitTimer = litTimer;
        if (isSpecial)
        {
            currentLitTimer = litTimer * 3;
            mr.material.mainTexture = specialLitTexture;
            special.PickRandom(transform.position);
        }
        else
        { mr.material.mainTexture = litTexture; }
        
    }

    public void turnSpecial()
    {
        TurnOffPanel();
        isSpecial = true;
        mr.material.mainTexture = specialUnlitTexture;
    }

    void TurnOffPanel()
    {
        if (isSpecial)
        {
            isSpecial = false;
        }
        mr.material.mainTexture = unlitTexture;
    }
}
