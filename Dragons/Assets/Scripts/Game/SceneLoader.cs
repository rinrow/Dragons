using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneManagerSO SceneManagerSO;

    private void OnEnable()
    {
        SceneManagerSO.OnDragonIconSelected += GoToTheCaveScene;
        SceneManagerSO.OnExitSelected += GoTheGameScene;
    }

    private void OnDisable()
    {
        SceneManagerSO.OnDragonIconSelected -= GoToTheCaveScene;
        SceneManagerSO.OnExitSelected -= GoTheGameScene;
    }

    private void GoToTheCaveScene()
    {
        SceneManager.UnloadSceneAsync("Game");
        GoToTheScene("Cave");
    }

    private void GoTheGameScene()
    {
        SceneManager.UnloadSceneAsync("Cave");
        GoToTheScene("Game");
    }

    public void GoToTheScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
    }
}