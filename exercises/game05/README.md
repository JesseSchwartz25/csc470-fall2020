# READ ME #

## Game Concept

Basically, my idea for my game is to make an isometric (duh) puzzle game revolving around building your character and then depositing bits of the playable character in order to solve puzzles. A concept for one puzzle is to collect collect a piece, then to drop that piece into a hole so that the playable character is able to cross a gap.

## Implementation

In order to have the player and its conjoined parts move how they are intended, any conjoined objects will become a child of the player object.


## Features

My goal is to create 2-3 puzzles/levels. Each level will be a different scene so that it is easy to reset the puzzles. Features I want to implement are:

* Detach pieces when they are above a gap
* Be able to combine and detach block with a mouse click
* a rotation peice, that allows a block to rotate and reorient itself (rotation is otherwise not something I intend to be a part of the Game)
* Jump pad that can launch that playable character into the air. The player will otherwise be unable to jump. I feel this will interact nicely with the gravity feature that detaches pieces when they are not grounded.
* pressure plates (like in portal)

## Things that may be difficult

Tracking the size of the player. if certain interactions require the player to be a certain size to do them, then we have to be able to know how large the player is at all times. The easiest way I see to control this is through the environment rather than code, because I feel like the code of a growing blob of player would be hard to keep track of. Rather, if a player can only be a certain size to create a certain interaction, the environment should not let them get to that point if they are to big or attached in the wrong orientation. 

If possible, I would like to implement a grid based movement system because I think it would really help to limit the amount of unitented interactions.