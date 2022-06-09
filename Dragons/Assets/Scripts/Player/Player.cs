using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerDataSO PlayerDataSO;
    public CaveSO CaveSO;

    public void OnEnable()
    {
        CaveSO.DragonEated += MinusFood;
    }

    private void OnDisable()
    {
        CaveSO.DragonEated -= MinusFood;
    }

    private void MinusFood(int num)
    {
        PlayerDataSO.MinusFood(num);
    }
}