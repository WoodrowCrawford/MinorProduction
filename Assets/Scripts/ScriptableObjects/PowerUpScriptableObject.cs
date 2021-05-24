using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PowerUp",menuName = "Power Ups")]
public class PowerUpScriptableObject : ScriptableObject
{
    public float PowerUpTimer;
    public bool isActive;
}
