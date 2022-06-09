using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonHousesManager : MonoBehaviour
{
    public PlayerInput PlayerInput;
    public Dragon Dragon;
    public Button _addDragonButton;
    
    private DragonHouse _dragonHouse;
    
    public event System.Action<DragonHouse> OnAddDragon;

    private void OnEnable()
    {
        _addDragonButton.onClick.AddListener(AddDragon);
        PlayerInput.OnDragonHouseSelected += DragonHousePressed;
    }

    private void OnDisable()
    {
        _addDragonButton.onClick.RemoveListener(AddDragon);
        PlayerInput.OnDragonHouseSelected -= DragonHousePressed;
    }

    private void DragonHousePressed(DragonHouse house)
    {
        DragonsIcons.Instance.Show(house);
        _dragonHouse = house;
    }

    private void AddDragon()
    {
        _dragonHouse.Add(Dragon);
        OnAddDragon?.Invoke(_dragonHouse);
    }
}
