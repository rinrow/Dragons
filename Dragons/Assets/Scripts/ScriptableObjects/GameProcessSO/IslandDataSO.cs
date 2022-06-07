using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class IslandDataSO : ScriptableObject
{
    public bool IsLoadData;

    //Временное решение
    [field: SerializeField]
    public List<DragonHouseData> DragonHousesData { get; private set; } = new List<DragonHouseData>();

    public void AddHouse(DragonHouse d)
    {
        DragonHousesData.Add(DragonHouseData.ConvertToDHD(d));
    }

    [ContextMenu("ClearAllData")]
    public void ClearHousesData() => DragonHousesData.Clear();
}

[System.Serializable]
public class DragonHouseData
{
    public Vector3 Position;
    public List<Dragon> Dragons;
    public int DragonsCount;

    //тк DragonHouse ссылочный тип можно и не возврашать новый обьект
    //а изменять обьект по ссылке
    public static void ConvertToDH(DragonHouseData data, DragonHouse result)
    {
        result.transform.position = data.Position;
        result.Dragons = data.Dragons;
    }

    public static DragonHouseData ConvertToDHD(DragonHouse house)
    {
        return new DragonHouseData()
        {
            Dragons = house.Dragons,
            Position = house.transform.position

        };
    }
}