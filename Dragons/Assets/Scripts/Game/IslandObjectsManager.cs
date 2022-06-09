using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandObjectsManager : MonoBehaviour
{
    public ObjectPositionSetter PositionSetter;
    public Island Island;
    public DragonHouse House;
    public ObjectsPosSettingSO HousePosSetterSO;

    private DragonHouse DefHouse;

    private void Start()
    {
        DefHouse = House;
    }

    private void OnEnable() => PositionSetter.OnHouseSetted += AddDragonHouseToIslandData;

    private void OnDisable() => PositionSetter.OnHouseSetted -= AddDragonHouseToIslandData;

    [ContextMenu("AddHouse")]
    public void S() => AddDragonHouse(DefHouse);

    public void AddDragonHouseToIslandData()
    {
        Island.AddHouse(House);
    }

    public void AddDragonHouse(DragonHouse dragonHouse)
    {
        //Должен быть
        //HousePosSetterSO.Raise(houseTr);
        //Но пока что
        //HousePosSetterSO.Raise(House);

        var house = Instantiate(dragonHouse, new Vector3(0, 0), Quaternion.identity);
        HousePosSetterSO.Raise(house.transform);
        House = house;
        //Нужно это кешировать
        //и добавлять в ScriptableObject 
        // и потом при каждом запуске выгружать оттуда данные
    }
}
