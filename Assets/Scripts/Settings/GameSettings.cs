using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Settings", order = 1)]
public class GameSettings : ScriptableObject
{
    public int levelDuration = 60; //seconds
    public int bombsOnLevel = 3;
    public int gameoverZombies = 3;

    public float speedBoostPerLevel = 0.2f;
    public float spawnTimeReduction = 0.1f;
    public int timeBetweenLevels = 4; // seconds

    public float bombRadius = 1.2f;
}
