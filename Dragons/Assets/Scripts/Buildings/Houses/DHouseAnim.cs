using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHouseAnim : MonoBehaviour
{
    public DragonHousesManager DragonHouse;
    public Animator Template;
    public Island Island;

    [Header("SpeedSettings")]
    public float _minSpeed;
    public float _maxSpeed;

    private void Awake()
    {
        Island.OnHouseInit += InitDragonAnim;
    }

    private void OnEnable()
    {
        DragonHouse.OnAddDragon += AddDragonAnim;
    }

    private void OnDisable()
    {
        Island.OnHouseInit -= InitDragonAnim;
        DragonHouse.OnAddDragon -= AddDragonAnim;
    }

    private void InitDragonAnim(DragonHouse house)
    {
        print("InitDragonsCalled");
        for (int i = 0; i < house.Dragons.Count; i++)
        {
            AddDragonAnim(house);
        }
    }

    private void AddDragonAnim(DragonHouse d)
    {
        var animator = Instantiate(Template, d.transform);
        animator.speed = Random.Range(_minSpeed, _maxSpeed);
    }
}
