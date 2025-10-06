# Spawner

To have enemies appear in the level, we take advantage of the Spawner class.  

The primary function inside EnemySpawner is the function SpawnEnemy.  

```
protected void SpawnEnemy(GameObject enemy, float spawnChanceTop, float spawnChanceRight, float spawnChanceBottom, float spawnChanceLeft, float maxAmountToSpawn)
```

It takes the game object of the enemy that is spawning, 4 float values that represent the likelihood it will spawn from a certain side of the screen, and a cap on how many to spawn in one frame, as running SpawnEnemy once has a potential to spawn 2 or 3 of said enemy in one frame *(it can depend on the enemy, and is determined by the Level Scriptable Object)*