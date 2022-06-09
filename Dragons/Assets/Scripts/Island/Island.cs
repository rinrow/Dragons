using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Point
{
    Empty, Busy
}

public class Island : MonoBehaviour
{
    public Vector2Int Size;
    public GameObject Tile;
    public Transform ParentPoint;
    public DragonHouse DragonHousePattern;

    [Header("Data")]
    public IslandDataSO IslandData;

    //Можно тоже в начале кешировать
    public static Dictionary<Vector3, Point> Points { get; private set; }

    private List<Vector3> _positions;
    private List<DragonHouse> _houses;

    public event System.Action<DragonHouse> OnHouseInit;

    private void Start()
    {
        _positions = new List<Vector3>();
        _houses = new List<DragonHouse>();

        if (IslandData.IsLoadData)
            InitializeHouses();
        InitializePoints(Size);
    }

    public void AddHouse(DragonHouse house)
    {
        var t = house.transform.position;
        IslandData.AddHouse(house);
    }

    private void InitializeHouses()
    {
        foreach (var item in IslandData.DragonHousesData)
        {
            var temp = Instantiate(DragonHousePattern);
            DragonHouseData.ConvertToDH(item, temp);
            _houses.Add(temp);

            OnHouseInit?.Invoke(temp);
        }
    }

    public void InitializePoints(Vector2Int size)
    {
        transform.localScale = new Vector3(size.x, size.y, 1);
        Points = new Dictionary<Vector3, Point>();

        var offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);

        for (int y = 0, i = 0; y < size.y; y++)
            for (int x = 0; x < size.x; x++, i++)
            {
                var pos = new Vector3(x - offset.x, 0.1f, y - offset.y);
                var tile = Instantiate(Tile, ParentPoint);
                Tile.transform.localPosition = pos;
                _positions.Add(pos);
                Points.Add(pos, Point.Empty);
            }
    }
}