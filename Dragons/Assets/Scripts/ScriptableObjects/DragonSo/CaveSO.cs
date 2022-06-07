using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CaveData")]
public class CaveSO : ScriptableObject
{
    public Dragon CurrentDragon;
    public event Action<int> DragonEated;

    public void Raise(int count)
    {
        DragonEated?.Invoke(count);
    }
}
