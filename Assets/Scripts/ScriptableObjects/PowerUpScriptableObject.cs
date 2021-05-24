using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PowerUp",menuName = "Power Ups")]
public class PowerUpScriptableObject : ScriptableObject
{
    public float BackupTimer;
    public float PowerUpTimer;
    public bool isActive;
}
