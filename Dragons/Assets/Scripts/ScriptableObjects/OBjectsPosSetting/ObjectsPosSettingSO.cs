using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsPosSettingSO : ScriptableObject
{
    public event Action<Transform> OnStartDragging;

    public void Raise(Transform t)
    {
        OnStartDragging(t);
    }
}
