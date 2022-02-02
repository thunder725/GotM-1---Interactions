using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// WARNING: 
// The code is messy because I spent 40 minutes debugging the events because the scripts subscribed to events AFTER BEING DESTROYED
// So the scripts kept being alive, but didn't do anymore Awake to unsubscribe, and their gameObjects were destroyed
// They were subscribed to an event without a gameObject, and gave errors trying to destroy it since it didn't exist anymore;
// And the whole thing gave errors, and if repeated multiple times prevented the game's music to stop when returning to the main menu
// Lesson learned: even if you destroy a GameObject, the script continues to function until every method has finished running
public class MainGameMusicSingleton : MonoBehaviour
{
    // Used only for the main menu music
    static MainGameMusicSingleton instance;

    void Awake()
    {
        // Debug.Log("SCRIPT NUMBER  " + this.GetInstanceID()  + "   LAUNCHES AWAKE");
        if (instance != null && instance != this)
        {
            SceneManager.activeSceneChanged -= SceneChanged;
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Apparently there is no "OnSceneChanged()" so I need to do it like that
            // I just used the same syntax as when doing an Input System Event, looks like it works
            SceneManager.activeSceneChanged += SceneChanged;
        }
    }

    void SceneChanged(Scene current, Scene next)
    {
        // Debug.Log("THIS OBJECT'S SCRIPT ID:  " + this.GetInstanceID());
        // Debug.Log("INSTANCE's ID:  " + instance.GetInstanceID());

        // For the case where you were in-game and you return to the main menu
        // Destroy even if DontDestroyOnLoad, and remove the instance so it can spawn again if you re-launch the game
        if (next.buildIndex == 0)
        {
            // Prevent memory leaks!!!
            SceneManager.activeSceneChanged -= SceneChanged;

            Destroy(gameObject);

            instance = null;
        }
    }
}
