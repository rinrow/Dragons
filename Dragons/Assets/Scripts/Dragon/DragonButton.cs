using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonButton : MonoBehaviour
{
    public Button Button;
    public CaveSO CaveDataSO;
    public SceneManagerSO SceneManagerSO;

    [HideInInspector]
    public Dragon Dragon;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        CaveDataSO.CurrentDragon = Dragon;
        SceneManagerSO.RaiseSelectedIcon();
    }
}
