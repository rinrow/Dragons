using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragonFeeding : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform _food;
    
    public CaveSO CaveSO;
    public PlayerDataSO PlayerDataSO;

    private Dragon currentDragon;
    private int _playerFood;
    private Vector2 _oldPos;

    private void Awake()
    {
        currentDragon = CaveSO.CurrentDragon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _oldPos = _food.position;
        _playerFood = PlayerDataSO.FoodCount;
        if (_playerFood < currentDragon.Appetite)
            Debug.LogError("Player doesnt have food enough");
    }

    public void OnDrag(PointerEventData eventData)
    {
        var r = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            var pos = hit.point;
            pos.z = 0;
            _food.position = pos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _food.position = _oldPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Должен перейти в old pos
        currentDragon.Eat();

        CaveSO.Raise(currentDragon.Appetite);

        print(currentDragon.EatedFood);
        print("OK");
    }
}