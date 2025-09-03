using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "New Level")]
public class LevelSO : ScriptableObject
{
    public int level = 1;

    [Header("Chaser Spawn Configuration")]
    public int chaserMaxCount = 16;
    public float chaserSpawnChanceTop = 100f;
    public float chaserSpawnChanceRight = 0f;
    public float chaserSpawnChanceBottom = 0f;
    public float chaserSpawnChanceLeft = 0f;
    public float chaserMaxAmountToSpawn = 4f;

    [Header("Asteroid Spawn Configuration")]
    public int asteroidMaxCount = 1;
    public float asteroidSpawnChanceTop = 10f;
    public float asteroidSpawnChanceRight = 10f;
    public float asteroidSpawnChanceBottom = 10f;
    public float asteroidSpawnChanceLeft = 10f;
    public float asteroidMaxAmountToSpawn = 1f;
}
