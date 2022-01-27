using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoulette : MonoBehaviour
{
    [SerializeField] GameObject SpecialShockwave;
    [SerializeField] int forceSPECIAL;
    [SerializeField] PlayerControl playerScript;
    [SerializeField] FirePillarSpawner SpecialPillar;
    [SerializeField] SpecialSlipperyFloor SlipperyFloor;

    public void PickRandom(Vector3 panelPosition)
    {
        int chosen;
        if (forceSPECIAL == -1)
        {
            chosen = Random.Range(0, 3);
        }
        else
        {
            chosen = forceSPECIAL;
        }
        switch (chosen)
        {
            case 0: // Shockwave
            Instantiate(SpecialShockwave, panelPosition + new Vector3(0, .8f, 0), Quaternion.identity);
            break;

            case 1:
            SpecialPillar.SpawnFirePillars();
            break;

            case 2:
            SlipperyFloor.player = playerScript;
            SlipperyFloor.StartingSlipperySlope();
            break;

            /*
            # 3 - Inverser contrôles
            # 4 - Speed * 2
            # 5 - Black Hole
            */
        }
    }

}
