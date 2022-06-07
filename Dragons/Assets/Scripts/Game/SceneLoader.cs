using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneManagerSO SceneManagerSO;

    private void Awake()
    {
        if (!SceneManagerSO.IsSceneLoadedOnce)
        {
            SceneManagerSO.IsSceneLoadedOnce = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        SceneManagerSO.IsSceneLoadedOnce = false;
    }

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

    private void GoToTheCaveScene() => GoToTheScene("Cave");
    private void GoTheGameScene() => GoToTheScene("Game");
    public void GoToTheScene(string sceneName) => SceneManager.LoadScene(sceneName);
}