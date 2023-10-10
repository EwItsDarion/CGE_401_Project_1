using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public GameObject ActiveCredits;
    public GameObject ActiveMainMenu;


    // Update is called once per frame
    public void changeToScene(int sceneToChangeTo)
    {
            FadeToLevel(sceneToChangeTo);
        sceneToChangeTo = sceneToChangeTo + 1;
    }

    public void showCredits()
    {
        ActiveCredits.SetActive(true);
        ActiveMainMenu.SetActive(false);
    }
    public void showMenu()
    {
        ActiveCredits.SetActive(false);
        ActiveMainMenu.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
