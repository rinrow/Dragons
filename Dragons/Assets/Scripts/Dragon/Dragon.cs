using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Dragon 
{
    public const float NewLevelMultiplier = 1.3f;
    public int Level { get; protected set; } = 0;
    public float Experiance { get; protected set; }
    public int EatedFood { get; protected set; }

    public string Name;

    [field: SerializeField]
    public int Health { get; protected set; }
    
    [field: SerializeField] 
    public int Damage { get; protected set; }

    [field: SerializeField] 
    public float FoodToNewLevel { get; protected set; }

    [field: SerializeField] 
    public int Appetite { get; protected set; }

    [field: SerializeField] 
    public Sprite Icon { get; protected set; }

    public void Eat()
    {
        EatedFood += Appetite;
        if (EatedFood >= FoodToNewLevel)
        {
            NewLevel();
        }
    }

    private void NewLevel()
    {
        EatedFood = 0;
        Level++;
        FoodToNewLevel *= NewLevelMultiplier;
        //Damage *= NewLevelMultiplier
        //è ò.ä
    }

    /// <summary>
    /// private static Dragon CreateDragon()
    ///{
    ///    return new Dragon()
    ///}
    /// </summary>
}