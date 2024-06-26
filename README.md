# Journey to Unity and C# game development

## Idea is to make a 2d ~roguelike~ roguelite where player fights waves of ~zombies~ Zombie Spaceships and can gain perks when leveling up

This readme will be in a form of a diary of sorts where I track the progress I have made in Unity and C#

Note that its a work in progress, things will change😄.

### Playtest 4.2.2024
<a href="https://www.youtube.com/watch?v=V9ToXcrTs7w">https://www.youtube.com/watch?v=V9ToXcrTs7w</a>

## How to try out the game yourself ##

### Game release ###

Game has not yet been released in any platform.

### Download from Drive (Windows only) ###

Built version of game can be found <a href="https://drive.google.com/drive/folders/1Ha3dPmnlT53kzcoakL0fJMSqqvh2m2uR?usp=sharing">here</a>:

### How to play ###

Moving: 
```
 W
ASD
```
Shooting:
    ``` Mouse 2 ```
    
Toggle automatic shooting:
    ``` T ```
    
Use rocket boosters:
    ``` Spacebar ```

## Potential future implementations
<li>Accessibility settings
  
- Audio
    
- Visuals
    
- Controller support
</li>
<li>Next Levels</li>
<li>More powerups</li>
<li>In depth stat tracking</li>

## Diary ##

<details>
  <Summary>
        Parts 1-15
  </Summary>

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
        Part 7 - Post Holiday and Covid:( (Level up rewards.)
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
        Part 10 - More foes!
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
<details>
  <Summary>
        Part 11 - Boosters and Powerups
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/af02d0e9-9ef8-4739-ba83-0ec06fbbd863"/>
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/727f0295-beed-449c-a76d-93a58c76c323"/>

Decided to implement a temporary rocket boost. Idea of the boost is the make the gameplay more deep allowing for more decision making in the heat of the action. Slow recharge and small delay between boosts. Booster bar can be seen in the bottom center of the screen, animations for boosters not yet implemented.

Finally embarked on the powerup journey, roguelikes need to have an rng based systems making different rounds feel different from each other (random levelup rewards part of this). Currently started on implementing how powerups can be picked up and how they affect gameplay, wrote some ideas on them in the <a href="https://github.com/Lauri-Iivarinen/spaceapocalypse/blob/main/todoAndNotes.txt">todoAndNotes.txt</a>. Right now implemented first powerup, spinning lightning beam that spawns every X seconds, spins 360 damaging everything the beam crosses. Need to implement better UI design for powerups in the future, right now hard coded position (Wont be good if player has multiple powerups on random basis).

Also noted how much simpler some mechanics are to create if I were to use static variables and methods, need to look into these in the future.
  
  <li>Rocket boosters, quick speedup to avoid mobs/mechanics</li>
  <li>Boosters recharge slowly</li>
  <li>Refactored folders for scripts etc.</li>
  <li>Basic Powerup system</li>
  <li>First powerup, spinning electric fence damaging mobs who cross paths with it</li>

  ### TODO:

  More powerups
  
  Powerups can be upgraded using level up system?
  
  Fix UI for powerups

  Figure out how player can get powerups (Mob drop/static spawn etc..?)
</details>
<details>
  <Summary>
        Part 12 - Polishing basic mechanics 2
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/7865bfed-5857-42ed-8087-1899492ae134"/>

  Noticed a major issue with static variables such as newly adapted kill count. Stats do not reset between runs which is an issue I had to fix, in the future I should switch over to static methods instead so I dont have to reset every static variable every time new game starts.

  After testing different roguelike games to harness ideas and gain inspiration (Don't want to directly copy ideas though 😙) made some notes and followed trough with some of them.

  Today I made a lot of changes that are not as concrete (visually) as I'd hoped but will have a major effect on future development. Also finally understood how 'Color' class works so was able to edit some colors (crit damage).
  
  <li>Mob health tuning and scaled in world size down</li>
  <li>Kill counter (see image)</li>
  <li>More upgradable stats (DR, XP gain)</li>
  <li>When powerup is picked it can be upgraded trough lvl up rewards</li>
  <li>Level up reward tuning</li>
  <li>Damage numbers round correctly</li>
  <li>Player can toggle automatic shooting by pressing 'F'</li>
  <li>Level up rewards can't be duplicates anymore</li>

  ### TODO:

  More powerups
  
  Fix UI for powerups
  
  Main menu long term stat upgrades, with currency?
  
  Boss mobs and mechanics
</details>
<details>
  <Summary>
        Part 13 - Long term roguelite mechanics and new talent
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/9af53e03-f55f-4290-a259-d82e140d47ca"/>
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/abda85b2-b8d6-49a7-b4b0-f659357c8497"/>

  The difference between rogue*like* and rogue*lite* is in the long term gain area. In traditional roguelikes player always starts the game with 0 powers and cant affect the base level of the characther at all. In roguelites players usually have a long term gain which helps the player to progress further everytime they unlock new perks.

  Created a long term buff section which can be accessed trough main menu between runs, there player can increase basic stats (damage, health, speed, exp gain etc...). Currently stats are always reset on game launch and need to be implemented using a database in the future (SQLite and EF Core). Upgrades can be purchased with a currency (Currently capped to 9999 for testing) and for now cannot be earned. Every level of upgrade increases to cost of the next upgrade. TODO regarding currency: Decide how it is gained. Also added a purchase option for extra life which has not yet been implemented.

  Integrating permanent buffs were in the end quite simple trough static variables however creating them was quite tedious. Also got a great chance to learn how to dynamically render items to player UI in the form of the upgrade stats/buttons.

  Also added a new powerup "Mine". Spawns a mine after a small delay, mine is "thrown" and travels for couple seconds before stopping and activating. Mobs crossing over mine will explode taking heavy damage. Mine radius has AOE. Also added mine to the levelup buffs.
  
  <li>Mob size scaled even more</li>
  <li>Permanent kill tracker in upgrade shop</li>
  <li>Permanent stat gain (Damage, health, speed ets...) <a href="https://github.com/Lauri-Iivarinen/spaceapocalypse/blob/main/Assets/scripts/Menu/PermanentStats.cs">Comprehensive list.  Rows 68-80</a></li>
  <li>Currency which can be used to purchase permanent upgrades, cannot be earned yet</li>
  <li>Refund purchased upgrades</li>
  <li>New talent Mine</li>
  <li>Mine can be upgraded trough level ups (Explosion radius, damage, spawn speed)</li>

</details>
<details>
  <Summary>
        Part 14 - New Mob and talent + development QoL
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/002300d8-8eb4-46b5-b0a1-6e4331411687"/>

  To reduce duplicate code I created a base class for all mobs which handles damage intake, xp gains etc. Now when creating a new mob I only need to implement how it moves and attacks. Also made a bunch of small changes that will hopefully help out in the future.

  Created a new mob "Ufo" to add more variety however it is only a basic melee mob. Nevertheless the game has now 5 different mobs that can attack the player. Im hoping to add few more this time with some unique mechanic/ability.

  Also while I was at it I created a new talent "Multishot". It shoots 3 bullets in a random direction (bullets are in a pattern). Bullet count/damage/firerate can be increased trough leveling up.
  
  <li>UI changes, powerup logic</li>
  <li>New melee mob "UFO"</li>
  <li>New talent "Multishot"</li>
  <li>Developer Quality of Life changes</li>
  <li>Player can only regain health when damaged</li>
</details>
<details>
  <Summary>
        Part 15 - Boss Time.
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/d7d08722-e6bd-4b98-8bcb-023b9a117fe2"/>
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/7a48e494-bc81-4d93-8150-4d87b5ade92b"/>

  Finally started to tackle the difficulty that is bossfights. Design of mechanics is not very hard with my extensive background of mmorpgs and raiding. However how to implement X mechanic and how does the boss rotate between different mechanics is the hard part.

  Did my best to reuse MobBaseline class but had to make some changes to it.

  Boss mechanics and features:
  <li>When bosses appear, their name and HP are displayed in UI.</li>
  <li>Shield protects boss from taking damage.</li>
  <li>Mines, boss throws occasionally mines, moving over it's own mine destroys shield.</li>
  <li>Spin around spawning large number of projectiles firing in all directions.</li>
  <li>Occasionally recharges shield.</li>
  <li>(Not implemented yet) Spawn multiple frontals, find safe space between.</li>
  
  TODO:
  <li>Decide and implement how boss spawns</li>
  <li>Endless map?</li>
  <li>Mob knockback on damage</li>
</details>
</details>
<details>
  <summary>Parts 16-</summary>

  <details>
  <Summary>
        Part 16 - Finalize bossfight
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/8f5db596-52e9-494e-ba38-6577ed780aa4"/>

  Up until this point my workflow in creating sprites has been to use 32x32 or 64x64 canvas to keep creations simple, however when I was scaling the boss the sprite became very bad quality because of the large scaling. I found a <a href="https://lospec.com/pixel-art-scaler/">website</a> that upscales pixel art and redid all boss sprites and animations with high resolution sprites. Im happy with outcome and will probably use the website more in the future.

  Also finalized the last bossmechanic "frontal" randomly chooses 2-4 frontals that spawn on fixed locations (Gun barrels). Player has always room to dodge but needs to be fast to find cover before beams explode.

  And to top things off, created a system for spawning mobs in waves and the match now consists of 8 minutes of increasing mob waves and a boss is waiting at the end.

  At the end of all this I built the project and did a proper <a href="https://youtu.be/w7QM6t7E6bs">playtrough</a> which I recorded for playback and debugging purposes.
  
  <li>Last mechanic, multi frontal</li>
  <li>Changed how mechanics rotate, instead of being random, mechanics are rotating on a fixed schedule</li>
  <li>Upscaled boss sprites</li>
  <li>Tuned boss sprite layering</li>
  <li>Mobs spawn in waves</li>
</details>
<details>
  <Summary>
        Part 17 - Some big not so visible tasks
  </Summary>

<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/3fd20230-4be9-46c0-b406-ff61019783fb"/>
<img height="200px" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/85ebd5a5-e1a0-4bd6-9266-6c0da7a62991"/>

  Finally decided to tackle the issue of confined play area. Ended up being more simple and easy as I had feared. Play area consists of 4 tiles (could be all unique but for now they are identical). Player starts at the center of 1 tile and the rest of the tiles are moved to the edges (and corner) closest where the player is in regards to the currently active tile.

Player starts at the center of the red 🔴 tile:

    🟩 🟥
    🟦 🟨

Moving right (player is still in red 🔴 square but close to the right edge):

    🟥 🟩
    🟨 🟦 
    
Then moving up (player is still in red 🔴 square but now closer to the top than bottom)
    
    🟨 🟦 
    🟥 🟩

  Now that the play area is "infinite" also tackled the way players can collect powerups, awarding is not yet decided but for now powerups are scattered quite far from each other. To be able to find the powerups I created indicators showing where the player should move to reach the powerup. Would be nice in the future if the arrows always hugged the edge of the canvas but after a very long debugging session I couldnt come up with a proper solution so sticking with the current implementation for now.

While implementing arrows I was happy 😃 to notice how easily I came up with the initial solution and how I quickly realised to create a new interface for pickups to allow for easy scalability.

  To top things off I downloaded some free to use fonts and imported them into the project to make it look more futuristic.
  
  <li>Infinite world</li>
  <li>Indicators indicating powerup locations</li>
  <li>Changed fonts in all menus and player UI:s</li>
  <li>Mob spawn tuning</li>

</details>
<details>
  <Summary>
        Part 18 - Game Audio, Navigation, Tuning
  </Summary>

No screenshots today. Created a level end screen after player successfully defeats a boss. This allows for multiply playtroughs in row.

Also started finally looking into game audio and how its played. Added initial sounds to basic mechanics (shooting/taking damage, talent mechanics etc.). Not quite happy with allthe effects but will have to do for now (I used free sound packages from Unity store).

Also did some small color changes to Main menu etc.
  
  <li>Game audio</li>
  <li>Bakcground music</li>
  <li>Level end screen after defeating a boss</li>
  <li>More mob spawn tuning</li>
  <li>Ui QoL changes</li>

</details>
<details>
  <Summary>
        Part 19 - Its 2 am... (At least it's Saturday😄)
  </Summary>
  
<img height="200px" alt="Näyttökuva 2024-2-4 kello 2 07 23" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/bdf928b8-306e-41a7-8fb8-badc7a5b3a2d">
<img height="200px" alt="Näyttökuva 2024-2-4 kello 2 13 18" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/3e0866e3-5140-48c4-b4a9-90690cafbab1">

I need sleep. Did a lot of things over the day...
  
  <li>Implemented currency system</li>
  <li>Implemented 2nd life permanent stat that hadnt been implemented yet (2nd screenshot).</li>
  <li>Mobs have 85% chance to drop a piece of currency that the player can then pickup to actually gain it.</li>
  <li>Permanent upgrade stats are now saved in a .dat file</li>
  <li>Player kills and currency are now saved in a .dat file</li>
  <li>Mob tuning</li>
  <li>Decided on initial values for all upgrade costs and increments</li>
  <li>Audio changes</li>

</details>
<details>
  <Summary>
        Part 20 - Big UI changes, playtest tuning.
  </Summary>


<img height="200px" alt="Näyttökuva 2024-2-4 kello 2 07 23" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/ba5f0665-f460-411d-8e1e-27d28b3975ae">
<img height="200px" alt="Näyttökuva 2024-2-4 kello 2 13 18" src="https://github.com/Lauri-Iivarinen/spaceapocalypse/assets/94760484/f2e5fb3a-f554-4849-a6e5-dabdfaec92a6">

I think I can finally say that first level is "done", and will not need changes maybe other than mob tuning and if I add more talents.

Did some more playtesting, this time I had some others testing as well giving good feedback on what to change.

Started changing the ui to be more user friendly, changed the menu to "float in space". Changed the upgrade shop to have a scrollable list of buffs with visual indicators for amount of upgrades aivailable instead of numbers.

Fixed some bugs as well.



New Playtest aivailable as well <a href="https://www.youtube.com/watch?v=V9ToXcrTs7w">https://www.youtube.com/watch?v=V9ToXcrTs7w</a>
  
  <li>Main menu UI changed</li>
  <li>Upgrade shop UI changed</li>
  <li>Level 1 mob tuning</li>
  <li>Audio changes</li>
  <li>Added audio to buttons</li>
  <li>Bug fixes</li>

</details>

</details>
