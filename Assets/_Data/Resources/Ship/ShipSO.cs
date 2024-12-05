using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObject/Ship")]
public class ShipIO : ScriptableObject
{
    public string shipName = "Ship";
    public int maxHP = 2;
}
