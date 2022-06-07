using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneManager")]
public class SceneManagerSO : ScriptableObject
{
    //Хз можно ли так делать с дата контейнером но другого выхода я пока не нашел
    public bool IsSceneLoadedOnce = false;

    public event Action OnDragonIconSelected;
    public event Action OnExitSelected;

    public void RaiseSelectedIcon()
    {
        OnDragonIconSelected?.Invoke();
    }

    public void Exit()
    {
        OnExitSelected?.Invoke();
    }
}
