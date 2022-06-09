using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataUI : MonoBehaviour
{
    [Header("UI")]
    public Text FoodCountText;
    public Text MoneyText;

    [Header("Event Senders")]
    public PlayerDataSO PlayerData;

    private void Start()
    {
        ShowFoodCountText(PlayerData.FoodCount);
    }

    private void OnEnable()
    {
        PlayerData.OnFoodCountChange += ShowFoodCountText;
    }

    private void OnDisable()
    {
        PlayerData.OnFoodCountChange += ShowFoodCountText;
    }

    private void ShowFoodCountText(int count)
    {
        if (FoodCountText != null)
            FoodCountText.text = "≈‰‡: " + count;
    }
}
