using System;
using System.Collections;
using UnityEngine;

public class ObjectPositionSetter : MonoBehaviour
{
    public ObjectsPosSettingSO PosSetting;
    public PlayerInput PlayerInput;

    private Transform _currentObject;
    private Vector3 _houseCurrentPosition;

    public event Action OnHouseSetted;

    private void OnEnable()
    {
        PosSetting.OnStartDragging += StartHousePositionSetting;
    }

    private void OnDisable()
    {
        PosSetting.OnStartDragging -= StartHousePositionSetting;
    }

    public void StartHousePositionSetting(Transform t)
    {
        _currentObject = t;
        PlayerInput.OnCursorOnPoint += DragDragonHouse;
        PlayerInput.OnCursorOnPointAndMouseButtonPressed += SetDragonHouse;
    }

    public void StopHousePositionSetting()
    {
        PlayerInput.OnCursorOnPoint -= DragDragonHouse;
        PlayerInput.OnCursorOnPointAndMouseButtonPressed -= SetDragonHouse;
    }

    private void DragDragonHouse(Vector3 pointPos)
    {
        var offset = new Vector3((_currentObject.localScale.x - 1) * 0.5f, 0, (_currentObject.localScale.z - 1) * 0.5f);
        _houseCurrentPosition = pointPos;

        _houseCurrentPosition = new Vector3(pointPos.x, pointPos.y + 0.1f, pointPos.z) + offset;
        _currentObject.transform.position = _houseCurrentPosition;
    }

    private void SetDragonHouse(Vector3 pos)
    {
        if (_houseCurrentPosition != Vector3.zero && Island.Points[pos] == Point.Empty)
        {
            _currentObject.transform.position = _houseCurrentPosition;
            _currentObject = null;
            StopHousePositionSetting();
            OnHouseSetted?.Invoke();
        }
    }
}


