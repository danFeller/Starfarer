Starfarer Docs
=================================

Welcome to the documentation for Starfarer. This goes over the object oriented programming behind how the game functions.

## Notable Features
Starfarer has 2 objects that make up the primary behavior of the game: Spawner and EnemyController. They are the classes that determine what enemies spawn in the level and how said enemies behave.
- There are currently 4 enemies implemented.
- The Spawner includes all the rules for what enemies spawn and how they spawn. Most notably, every child of the Spawner class has a function called SpawnEnemy, where they determine what side of the screen to spawn the enemy on.

Inside the Assets folder is the scripts folder that contains all the behavior scripts for the game's mechanics.
- The Game folder contains code for changing from the game's main menu to the game itself. It also contains management for the scoring system.
- The NPC folder contains all the logic for how each enemy in the game behaves. The EnemyController is meant to be parent class holding most of the behavior models the children can use. EnemyController is like a library that holds a collection of functions for different behavior patterns, and the children can call on a combination of said functions to create a variety of different movement patterns (WIP).
- The Pickups folder is logic for items you can acquire in the game. Currently, there's only a multiplier pick-up. There's meant to be more than 1 item type (WIP).
- The Player folder holds the controls for the player, featuring omni-directional aiming instead of constant upward aiming in traditional retro shooters like Galaga or Xevious.
- The Projectiles folder has movement behavior for different Bullets. There's a bullet representing the player's projectiles and one for the Peashooter, currently the only enemy with its own projectiles.
- The Scriptable folder contains an object that acts as a template for how often specific enemies spawn. Each instance of this class controls how many of a certain enemy can be on screen and the chance for said enemy to spawn on a given side of the screen.
- The Spawner folder holds the different spawners that instantiate the enemies found in the NPCs folder. Each Spawner is a child of the parent spawner class. In the parent, the SpawnEnemy function is used by all the enemy children to determine if and where to spawn a specific enemy. There's different weights for how often an enemy spawns from a different side of the screen, so there needed to be 4 different child classes 
that obtain their separate spawning rules from the Level object found in the Scriptable folder.