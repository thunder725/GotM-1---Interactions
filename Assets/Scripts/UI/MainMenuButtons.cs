using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel;
    static bool hasBeenSetup;
    [SerializeField] GameObject[] TutorialUsefulPieces;
    [SerializeField] Button PlayButton, ReturnButton;


    void Start()
    {
        if (!hasBeenSetup)
        {ExitTutorial(); hasBeenSetup = true;}
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        Debug.Log("e");
        MainMenuPanel.SetActive(false);
        foreach (GameObject g in TutorialUsefulPieces)
        {
            g.SetActive(true);
        }
        ReturnButton.Select();
    }

    public void ExitTutorial()
    {
        MainMenuPanel.SetActive(true);
        foreach (GameObject g in TutorialUsefulPieces)
        {
            g.SetActive(false);
        }
        PlayButton.Select();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
