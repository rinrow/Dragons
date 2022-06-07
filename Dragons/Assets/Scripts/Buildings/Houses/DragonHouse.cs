using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHouse : MonoBehaviour
{
    public CaveSO CaveTransition;

    [SerializeField]
    private List<Dragon> dragons;

    public List<Dragon> Dragons { get => dragons; set => dragons = value; }

    public void Add(Dragon dragon)
    {
        Dragons.Add(dragon);
    }   
}