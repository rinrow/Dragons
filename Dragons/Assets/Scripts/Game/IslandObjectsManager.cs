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
        //������ ����
        //HousePosSetterSO.Raise(houseTr);
        //�� ���� ���
        //HousePosSetterSO.Raise(House);

        var house = Instantiate(dragonHouse, new Vector3(0, 0), Quaternion.identity);
        HousePosSetterSO.Raise(house.transform);
        House = house;
        //����� ��� ����������
        //� ��������� � ScriptableObject 
        // � ����� ��� ������ ������� ��������� ������ ������
    }
}
