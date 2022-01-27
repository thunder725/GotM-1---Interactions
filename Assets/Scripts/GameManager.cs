using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    PlayerControlInputs inputs;
    public static bool isPlayerDead;
    // DON'T
    public static bool isDebugModOn;
    [SerializeField] bool enableDebugMode; 
    void Awake() { inputs = new PlayerControlInputs(); isPlayerDead = false;}
    void OnEnable() { inputs.Enable(); inputs.Default.Restart.started += Restart; }
    void OnDisable() { inputs.Disable(); inputs.Default.Restart.started -= Restart; }

    public static void Restartlevel()
    {
        // Debug.Log("Here We Go");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        isDebugModOn = enableDebugMode;
    }

    void Restart(InputAction.CallbackContext c)
    {
        // Debug.Log("R KEY");

        // Should I put this in Debug Mod only? I don't think so but maybe?
        Restartlevel();
    }

}
