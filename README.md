# Starfarer
This is a rail shooter made in my personal time. It is built in C# using Unity 6.

## Notable Features
Starfarer has 2 objects that make up the primary behavior of the game: Spawner and EnemyController. They are the classes that determine what enemies spawn in the level and how said enemies behave.
- There is currerntly 2 (out of the 5) enemies implemented, and it would be surprisingly easy to build more with the EnemyController object I made.
- The Spawner includes all the rules for what enemies spawn and how they spawn. Most notably, every child of the Spawner class has a function called SpawnEnemy, where they determine what side of the screen to spawn the enemy on.

More to come...
