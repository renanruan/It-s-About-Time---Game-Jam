using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitioner : MonoBehaviour
{
    private static LevelTransitioner Instance;


    public Animator TransitionAnimator;

    private string SceneToLoad;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ShowCurrentScene();
    }

    private void ShowCurrentScene()
    {
        TransitionAnimator.SetTrigger("ShowCurrentScene");
    }


    private void StartiTransitionToScene(string sceneName)
    {
        PrepareNewScene(sceneName);
        HideCurrentScene();
    }

    private void PrepareNewScene(string sceneName)
    {
        SceneToLoad = sceneName;
    }

    private void HideCurrentScene()
    {
        TransitionAnimator.SetTrigger("HideCurrentScene");
    }


    private void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
    }

    public static void ChangeToScene(string sceneName)
    {
        Instance.StartiTransitionToScene(sceneName);
    }

    public static void RestartScene()
    {
        Instance.StartiTransitionToScene(SceneManager.GetActiveScene().name);
    }
}
