using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������� ������� dragonHouse-List<Button> ����� ���� ����� 
/// ��� ����� ��� ���� ����� � �� ���� ���� ��������� � ������� ���� ���� �����
/// </summary>
public class DragonsIcons : MonoBehaviour
{
    public static DragonsIcons Instance { get; private set; }

    public Button Template;
    public PlayerInput PlayerInput;

    private int _dragonsCount = 5;
    private List<Button> _icons;
    private Vector2 _basePos;
    private float _delta;
    private DragonHouse _dragonHouse;
    private bool _isInitialized = false;
    private List<GameObject> _activeButtons;

    private void Awake()
    {
        Instance = this;
        _icons = new List<Button>();
        _activeButtons = new List<GameObject>();

        //����� ������ �����������, � �� ������ ��� ����� ���������
        _basePos = new Vector2(0, 217f);
        _delta = Template.GetComponent<Image>().rectTransform.rect.width + 10;//width
    }

    private void OnEnable()
    {
        PlayerInput.OnDontPressIcon += UnShow;
    }

    private void OnDisable()
    {
        PlayerInput.OnDontPressIcon -= UnShow;
    }

    public void Show(DragonHouse house)
    {
        _dragonHouse = house;
        var count = _dragonsCount = house.Dragons.Count;
        var pos = _basePos;

        ///<summary> ����� ��� ������ ���������� ������ ������� ���������������� �� �����
        ///if (!_isInitialized)
        ///{
        ///    //������� � ������ � ����� �������
        ///    
        ///    _isInitialized = true;
        ///}
        /// </summary>
        InitalizeElements();

        for (int i = 0; i < count; i++)
        {
            _icons[i].gameObject.SetActive(true);
            _activeButtons.Add(_icons[i].gameObject);
            var t = _icons[i].GetComponent<RectTransform>();
            t.anchoredPosition = pos;
            pos.x += _delta;

            var dragonIcon = _icons[i].GetComponent<DragonButton>();
            dragonIcon.Dragon = _dragonHouse.Dragons[i];

            _icons[i].image.sprite = _dragonHouse.Dragons[i].Icon;
        }
    }

    private void UnShow()
    {
        foreach (var button in _activeButtons)
        {
            button.SetActive(false);
        }

        _activeButtons.Clear();
    }

    private void InitalizeElements()
    {
        var temp = _icons.Count - _dragonsCount;
        if (temp >= 0) return;
        temp *= -1;
        for (int i = 0; i < temp; i++)
        {
            _icons.Add(Instantiate(Template, transform));
            _icons[i].gameObject.SetActive(false);
        }
    }
}
