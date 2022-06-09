using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataStorer")]
public class PlayerDataSO : ScriptableObject
{
    public int FoodCount;
    //Experiance � �.�

    public event Action<int> OnFoodCountChange;

    public void MinusFood(int count)
    {
        FoodCount -= count;
        OnFoodCountChange?.Invoke(FoodCount);
    }
}
