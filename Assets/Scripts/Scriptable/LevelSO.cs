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

    [Header("Dasher Spawn Configuration")]
    public int dasherMaxCount = 0;
    public float dasherSpawnChanceTop = 50f;
    public float dasherSpawnChanceRight = 10f;
    public float dasherSpawnChanceBottom = 10f;
    public float dasherSpawnChanceLeft = 50f;
    public float dasherMaxAmountToSpawn = 3f;

    [Header("Peashooter Spawn Configuration")]
    public int peaShooterMaxCount = 0;
    public float peaShooterSpawnChanceTop = 50f;
    public float peaShooterSpawnChanceRight = 10f;
    public float peaShooterSpawnChanceBottom = 10f;
    public float peaShooterSpawnChanceLeft = 50f;
    public float peaShooterMaxAmountToSpawn = 3f;
}
