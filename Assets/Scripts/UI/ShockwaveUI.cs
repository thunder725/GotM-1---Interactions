using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShockwaveUI : MonoBehaviour
{
    [SerializeField] PlayerControl playerScript;
    [SerializeField] Image shockwaveFillBar, spaceBarImage, rightTriggerImage;
    [SerializeField] Color readyColor, unreadyColor;
    Color transparentColor;
    [SerializeField] [Range(0, 1)] float transparencyValue;

    void Start()
    {
        transparentColor = new Color(1,1,1,transparencyValue);
    }

    void Update()
    {
        if (playerScript.currentShockwaveCooldown > 0)
        {
            shockwaveFillBar.fillAmount = (playerScript.shockwaveCooldown - playerScript.currentShockwaveCooldown) / playerScript.shockwaveCooldown; 
        }
    }

    public void ShockwaveUsed()
    {
        shockwaveFillBar.color = unreadyColor;
        spaceBarImage.color = rightTriggerImage.color = transparentColor;
    }

    public void shockwaveFilled()
    {
        // This shouldn't be used because of course it's one it has been checked in the Update
        // But the Debug Mode "Fill Shockwave" doesn't fill it visually so I'm double filling it here too
        shockwaveFillBar.fillAmount = 1;
        shockwaveFillBar.color = readyColor;
        spaceBarImage.color = rightTriggerImage.color = Color.white;
    }
}
