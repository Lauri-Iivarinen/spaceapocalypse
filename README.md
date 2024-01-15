# Journey to Unity and C# game development

This readme will be in a form of a diary of sorts where I track the progress I have made in Unity and C#


## Idea is to make a 2d roguelike where player fights waves of ~zombies~ Zombie Spaceships and can gain perks when leveling up

<details>
  <Summary>
        Part 1 - Getting started
    </Summary>

  <img height="300px" src="https://github.com/Lauri-Iivarinen/zombacopalypse/assets/94760484/c46e0c6e-c1bc-4ed4-a51a-67949a1eb4f6"/>

  No idea how to develop games in Unity and only small experience with C# in the form of a couple leetcode problems, however my experience with Java will help.
  <li>Multiple hours of YouTube tutorials later I have Unity open and a project running</li>
  <li>Project has different objects with different properties</li>
  <li>Player can move around</li>
  <li>Player can turn towards cursor</li>
  <li>Player can shoot projectiles towards cursor</li>
  <li>Player can damage 'Zombies'</li>
  <li>Player can take damage from 'Zombies'</li>
  <li>Rough sketch for UI to test how different classes interact</li>
</details>
<details>
  <Summary>
        Part 2 - Basics under control
    </Summary>

  <img height="300px" src="https://github.com/Lauri-Iivarinen/zombacopalypse/assets/94760484/aa0896a8-06c2-454d-99aa-6b13bab9f29e"/>

  Continued where I left off, sketched new model prototypes, need to create sprites soon. A lot of tutorials on YouTube which help a lot. Planning to extend player stats building. Need to look into different views (Menu/death screen etc.)
  <li>Removed excess models from the world and created prefabs</li>
  <li>Mobs spawn on timer and outside of player view</li>
  <li>Mobs chase player, no pathfinding if/when obstacles are created in the future</li>
  <li>Player has multiple guns that can be switched between</li>
  <li>Guns have different stats that affect gameplay (firerate/damage etc.)</li>
  <li>Player can level up</li>
  <li>UI changes</li>
</details>
<details>
  <Summary>
        Part 3 - Models and mistakes
    </Summary>

  <img height="200px" src="https://github.com/Lauri-Iivarinen/zombapocalypse/assets/94760484/b7ce6ca5-7367-4a9d-a3b6-a0cfb4591f5f" />
  <img height="200px" src="https://github.com/Lauri-Iivarinen/zombapocalypse/assets/94760484/6b8f9940-da88-42f3-bc9c-ad143fd248a7" />

  Looked into sprites and decided on art direction (was thinking about pixel/cartoon but ended up using free models from <a href="https://www.mixamo.com/#/">Mixamo</a>

  **Then ended up messing up git version** control and had to backtrack quite a lot to redo things :(

  Next up need to look into level creation, probably in blender
   <li>Barebones main menu and navigation</li>
   <li>Pause menu</li>
   <li>Player model and baseline walking animation</li>
   <li>Zombie model and animation</li>
  <li>Refined some game logics</li>
  <li>Tested out building project into executable</li>
</details>
<details>
  <Summary>
        Part 4 - Rusting off blender
    </Summary>

  Did some fine tuning with collision detection, now player can be confined within a play area, affects mobs also. Started doing some rough mocks for some models what I could include in the world, also created some guns for the player.
  <li>Collision detection</li>
  <li>Weapon models and basic weapon animation</li>
  <li>Some basic models for cars</li>
</details>
<details>
  <Summary>
        Part 5 - Massive art overhaul and new direction 
    </Summary>


<img height="200px" src="https://github.com/Lauri-Iivarinen/zombapocalypse/assets/94760484/9e14ccb6-1924-4fcc-910e-d222d77d8152"/>  


  After sleeping on the modeling and how the animations turned out I was extremely disappointed and thought what could I do... A thought came into mind, what if I change the gameplay from a "soldier" to a space rocket....

  This way I was able to create easy pixelated sprites and animating sprites was much easier as well since they require only few keyframes.

  After thinking about it for a while I did my testrun with the rocket and was extremely happy how it turned out so I decided to "full send" and I could not be more pleased...

  Luckily all mechanics are applicable here as well
  
  <li>New player sprites and animating</li>
  <li>New mob sprite and animating</li>
  <li>New background and parallax effect</li>
  <li>Asteroids to fill the play area (and block it off)</li>
  <li>Decided on "class/itemization"</li>
  <li>Got rid of some access code and cleaned up classes</li>
</details>
<details>
  <Summary>
        Part 6 - New Mob type
    </Summary>


<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/d2af0b74-8310-42ae-abb8-0a3f54d3bd71"/>  

  Created new class selection screen, no longer weapon switching, you choose before game and play with the choice.
  
  Feeling encouranged with the new art direction and progress I made I decided to push on. Making different type of enemies was the goal from beginnign and I decided to tackle the new ranged attacking mob now.
  
  Ended up being easier than I though since I could just make a new collision detector for the mobs to decide if they are close enough to start shooting towards player
  
  <li>Mob and player explosions on death</li>
  <li>Class selection screen</li>
  <li>New stats in class affecting gameplay (speed, hp etc.)</li>
  <li>New enemy, ranged</li>
  <li>Mob spawning changes to spawn around player and never outside playable boundaries</li>
</details>
<details>
  <Summary>
        Part 7 - Post Holiday and Covid:(
    </Summary>


<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/c00ed48d-fb60-45fc-bf1b-4ba526be9853"/>
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/1a9c2523-05f3-4b6e-93e7-5cf572ab6e6c"/>

  Took a big break to enjoy Holidays with family and wasnt able to get back to business untill couple weeks after new years because I ended up getting Covid from somewhere. 
  
  Anyways back to business as usual. Fixed all stats not being applied so that player can increase them when leveling up, currently 6 different stats to upgrade, when leveling up random selection of 3 appears where player chooses 1 to buff.
  
  <li>Level Up Screen</li>
  <li>Upgrade stats when leveling Up</li>
  <li>All player stats effect gameplay</li>
  <li>Baseline stats display on top right of screen</li>
  <li>Player attacks have a chance to critically strike mob increasing damage the attack deals</li>
  <li>Upgraded death animation to ranged mob</li>
  

  ### TODO:

  Mobs drop health pickups on death
  
  More Upgradable stats (Bullet penetration etc.)
  
  Automatic Health Regen (and stats for it)
</details>
<details>
  <Summary>
        Part 8 - Polishing basic mechanics
    </Summary>

  
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/38e97b2a-ecd2-4132-a90a-62b66e5b6354"/>

  Did a small change around how collision works so bullet penetration can work properly. Speaking of which player can now have bullet penetration stat (10% penetration = every 10th bullet penetrates once extra).

  Also worked on some fine tuning and made it easier to tweak certain stats (Mob xp rewards, player hp gains, leveling up...).

  Player can now also regenerate health by mob drops, 10% chance to drop hp capsule that can be picked up to heal a lot and player also has passive but very slow health regen which ticks every 4 seconds. Taking damage should not be ideal so   
  passive regen is very slow.
  
  <li>Passive HP Regeneration</li>
  <li>Mobs can drop HP capsules</li>
  <li>Bullets can penetrate (properly)</li>
  <li>New level up rewards: HP Regen and Bullet penetration</li>
  <li>Fixed diagonal movement being ~40% faster than intended</li>
  
</details>
<details>
  <Summary>
        Part 9 - Interfaces and damage numbers
  </Summary>

  
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/23fe0a4a-ade0-4253-91b5-522df8118a27"/>

  There is nothing more satisfying than seeing the BIG damage you do to the enemies and displaying that with numbers is an easy and classic way to make players feel more powerful the more powerups they gain.

  Also noticed a bug after implementing damage numbers where ranged mobs were taking damage even when bullet enters their range finder trigger, this was not intended...

  Fixing this bug meant I needed to find a new way to recognice hit and make mobs take damage. By making a simple interface to mobs I was able to achieve this surprisingly easy.
  
  <li>Floating damage numbers</li>
  <li>Floating healing numbers</li>
  <li>Numbers tuning so that health etc is not calculated in decimals</li>
  <li>Leveling up plays an animation (done after recording gif)</li>
  
</details>
<details>
  <Summary>
        Part 9 - More foes!
  </Summary>

  
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/bcde80e1-66a2-40d8-8dcc-f27e4887ccb0"/>

  To increase variety in mob types implemented 2 more mobs from the readme plans, quick melee mob with low hp "Glass cannon" of sorts and a frontal caster.

  Fast melee mob was as easy as just making a new sprite and animations and then copying 1st melee mob prefab and just tuning the numbers on it (luckily made it semi easy the first time, now even more easier in the future)

  Frontal caster reaches x distance and initiates cast, cast is 1.5sec duration after which if player is in contact with the frontal trigger player takes massive damage. Indicator was quite repetitive to paint in Gimp 😿
  
  <li>Floating damage numbers now integers</li>
  <li>New mob, fast melee mob with high damage, low hp</li>
  <li>Frontal caster mob, easy to dodge, big damage</li>
  <li>Overall numbers tuning</li>
  <li>Refactoring few instances to make future development easier</li>
</details>
