using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool _isFollows = false;
    private bool _isDragonhousePressed = false;

    private Vector3 _pos = Vector3.zero; //Vector.zero алтернатива null

    private Camera _mainCamera;

    private RaycastHit _hit;
    private RaycastHit2D _hit2d;

    public event Action<DragonHouse> OnDragonHouseSelected;
    public event Action<Vector3> OnCursorOnPoint;
    public event Action<Vector3> OnCursorOnPointAndMouseButtonPressed;
    public event Action OnDontPressIcon;

    private void Start()
    {
        _mainCamera = Camera.main;
        _hit2d = new RaycastHit2D();
    }

    void Update()
    {
        var r = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _hit2d = Physics2D.Raycast(_mainCamera.transform.position, Input.mousePosition);

        //луч не попадает в кнопку
        if (!_hit2d && _isDragonhousePressed && Input.GetMouseButtonDown(0))
        {
            _isDragonhousePressed = false;
            IconNotPressed();
        }

        if (Physics.Raycast(r, out _hit))
        {
            if (_hit.transform.TryGetComponent<DragonHouse>(out DragonHouse house) && Input.GetMouseButtonDown(0))
            {
                _isDragonhousePressed = true;
                DragonHouseSelected(house);
            }

            else if (_hit.transform.CompareTag("Point"))
            {
                _pos = _hit.transform.position;
                _isFollows = true;

                CursorOnThePoint(_pos);
            }
            else if (Input.GetMouseButtonDown(1) && _isFollows)
            {
                _isFollows = false;
                CursorOnThePointAndMouseButtonPressed(_pos);
            }
        }
    }
    private void DragonHouseSelected(DragonHouse house)
    {
        OnDragonHouseSelected?.Invoke(house);
    }

    private void CursorOnThePoint(Vector3 pointPos)
    {
        OnCursorOnPoint?.Invoke(pointPos);
    }

    private void CursorOnThePointAndMouseButtonPressed(Vector3 pointPos)
    {
        OnCursorOnPointAndMouseButtonPressed?.Invoke(pointPos);
    }

    private void IconNotPressed()
    {
        OnDontPressIcon?.Invoke();
    }
}



