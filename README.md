# GAME OF GOOSE 

![image](https://github.com/MichWouters/GameOfGoose.Template/assets/16591386/a5cfa405-7b78-4dc3-a446-0f0210f43ef4)

[www.dotnetacademy.be ](http://www.dotnetacademy.be/)

## Introduction 

The purpose of this exercise is to master the SOLID principles, by creating a console app to implement the game of goose. 

The game has to support creating  1 - 4 players whereby each player controls his piece.  

Game of the Goose 

The Game Of the Goose is a board game where two or more players move pieces around a track by rolling two dice. The aim of the game is to reach square number sixty-three before any other players while avoiding obstacles such as the inn, the Bridge and Death. 

There are 63 numbered spaces in the Game Of Goose. 

![image](https://github.com/MichWouters/GameOfGoose.Template/assets/16591386/3cf60543-cc42-44c4-a204-368c6ad50e26)
## The spaces 

The Game of Goose has 63 spaces.  Some spaces are “static”, but lots of spaces have a special meaning.  There are also those spaces with a Goose on them.  Let’s go in detail here. 

Special Spaces: 

|Number |Name |Meaning |
| - | - | - |
|6 |Bridge |Go to 12 |
|19 |Inn |Skip one turn |
|31 |Well |If you come here, you need to wait until another player arrives.  The one who was there first can continue playing |
|42 |Maze |Go back to 39 |
|52 |Prison |Skip 3 turns |
|58 |Death |Go back to start |
|63 |End |The first player who arrives here, wins the game |

## Spaces with a Goose 

Spaces with a goose on them are the following: 

- 5 
- 9 
- 14 
- 18 
- 23 
- 27 
- 32 
- 36 
- 41 
- 45 
- 50 
- 54 
- 59 

If you land on a space with a goose, you can move your piece forward with the number of eyes on the dice you have rolled.  Your piece cannot stand on a space with a goose. 

**Exceptions** 

- If you throw 5+4 on the first throw, you go to space 26 
- If you throw 6+3 on the first throw, you go to space 53 

### Hitting 63 

When reaching the end of the Game Of Goose, you need to hit space 63 **exactly.**  If you have thrown too much, you need to move your piece in the reverse order over the board. If you hit a Goose “in reverse”, the normal rule applies and you need to add the number you have thrown with the dice. 

**For Example:** 

You are on space 57 and you throw 5+5. Your piece does this: 58, 59, 60, 61, 62, 63, 62, 61, 60, 59 (this is a Goose) => go to 49. 

Note that this rule greatly increases the odds that a player hits death (58). 

### Tips: 

Create the base game first, in code, using a single player. Try creating your game by using the Test- Driven Design approach. You can verify the behaviour of methods using Unit tests. Once the game logic is solid, you can add a fancy UI and multiple players. 

Your application should be loosely coupled. Apply the Open Closed Principle by letting the tiles themselves decide what happens to the player, not the other way around. This way you can add new tile types or remove unused ones later down the line, without having to modify existing code.  

Have fun! 

® copyright by[ www.dotnetacademy.be ](http://www.dotnetacademy.be/)
