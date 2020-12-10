# Chair Surfer 3000


![alt text](https://github.com/JesseSchwartz25/csc470-fall2020/blob/master/exercises/final/Screen%20Shot%202020-12-10%20at%202.02.50%20PM.png)


## Gameplay

The entire game takes places on a downhill slope filled with office chairs. The chairs are rolling down the slope. As the player, you are trying to survive on the chairs for as long as possible. When a player is on a chair, they will be spinning (because it's an office chair), and eventually will have to jump off in the direction of another office chair. The direction they jump will be decided by the direction that the chair is facing. The game is over when the player does not land on another office chair. If the chair or player falls off the road, they also lose.


## Input

The player controlls when they jump with the spacebar and their movement in the air with WASD. Theses can be upgraded by using coins in the store. The player can also affect the rotation of their chair with A and D. Some chairs are easier to control than others.

## Visual Style

the palette of this game ended up going much more Miami Vice than U had originally intended. I think I was inspired by Cyberpunk to have lots of neons and pinks/blues. I was also severly limited by the amount of models available on google poly for me to choose from because I am not skilled enough to make a chair, human, car, building, road, or coin look good enough.

## Audio

The audio in this game has a very surf heavy vibe, with 50's electric surf rock playing during gameplay and waves playing during the start screen. There is elevator music in the other screens and a few sound effects that come during gameplay to make the game feel more responsive.


## Interface

In game, there is a counter for your score, how many lives left (ie: bounces on the ground), and coins you have.

The start screen has buttons which direct you to other parts of the game and an indicator for your high score.

The store is built with buttons that show you the cost of upgrading your skills.


## Story/Theme


The theme of this game is surfing on chairs and that is the story as well. Don't think too hard about it.


# Feature Sets

## Low Bar

>>A complete game would feature a totally workable chair surfing mechanic that is "fun" and complete. This means that the jumping works as expected, chairs act as expected, game objects spawn and despawn correctly, and a score counter for people to track their high scores. Ideally this will be an endless game, but I dont know how hard that will be to implement (So endless runner might change which target set its under depending on how hard it is, but it's definitelly something I want).

**This bar was reached entirely!**




## Target

>>My expectation is that I can complete all the above, as well as add powerups to the game like a bubble that lets the player bounce on the track withought needing the chairs, a magnet which attracts chairs, or a speedboost. I also want to have some kind of coins that the player can collect which will help them boost their score.

I ended up pushing powerups as I realized that other components of the game were more important. I did, however, add coins, which are a pivotal part of the games design.

**Half of this bar was reached, the other half became a stretch goal which was not reached.**


## High Bar 

>>If everything goes well, I would like to expand on the coin system so that players can buy upgrades. This would include increased stats like a higher jump or a longer time to stay on a chair before it breaks (or they fall off, I havent really figured out exactly what that will look like.)

**The store is implemented.**

>>I also would like to add the possibility for different chairs to spawn, which could have increased stats over the traditional office chairs. Players could buy the chance for this to happen more often.

**There are two different types of chairs that spawn**


**This bar was reached!**



## Extreme 

>>If everything goes well or if it turns out some of this is really ease and/or impossible for me, another goal of mine is to add environmental hazards. Generally I don't want the player to worry about falling off the ramp/slope, but I want the chairs to be able to fall off, so there will be a railing keeping the player on but letting chairs out underneath (this is part of my low-target area feature sets). I would also like to add sections where the railing dissappears so the player is in more danger. I would also like to play with ramps and pits to see if thats someting I can work with. I have a feeling this will be difficult when adding this to the endless runner aspect of the game.


**While I didn't necesarilly complete the goal I had in mind for this bar, I did discover that falling off the edge was an important mechanic for needing to transfer chairs. Although I didn't add ramps or pits, I did add cars which act as obstacles!**

**This bar was mostly met**



# Timeline

If I had more time to work on the game, I would refine the jumping and spawning mechanics, as well as add powerups.

Spawning is often jittery and in the field of view of the player which is sort of jarring. In order to fix this I would have to make the road longer, which would mess up all of the math that is already hard coded into the game. While that may be worth it if I ever further pursue this game, it was not given the time crunch.

Powerups would be cool to add, I just ran out of time to implement, test, and make sure that they meshed well with the rest of the game.










