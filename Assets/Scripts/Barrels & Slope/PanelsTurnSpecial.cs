using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsTurnSpecial : MonoBehaviour
{
    [SerializeField] bool forceSPECIAL;

    [SerializeField] float specialChancePerSecond;
    [SerializeField] GameObject slopeContainer;
    List<GameObject> panelsList = new List<GameObject>();
    float timer;

    void Awake()
    {
        foreach(Transform _c in slopeContainer.transform)
        {
            panelsList.Add(_c.gameObject);
        }
        timer = 1;
    }

    void Update()
    {
        if (!GameManager.isPlayerDead)
        {   
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1;
                if (Random.value < specialChancePerSecond)
                {
                    TurnSpecial();
                    // Debug.Log("YOU'RE S.P.E.C.I.A.L.");
                }
            }
        }
        if (forceSPECIAL)
        {
            forceSPECIAL = false;
            if (GameManager.isDebugModOn)
            {TurnSpecial();}
        }
    }

    void TurnSpecial()
    {
        // Select one random, turn it special
        panelsList[Random.Range(0, panelsList.Count)].GetComponent<SlopePanels>().turnSpecial();
    }
}
