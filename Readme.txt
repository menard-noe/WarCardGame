Modelisation of the card game War. 

Entrypoint Main located in WarCardGame.ConsoleApplication.cs
If you want to specify cards for the players, the cards have to be to the format : 4C 5H 6S 7H 1D 13D
With 1 the Ace, 13 the King, 12 The queen and 11 the Jack.
C = clover
H = heart
S = spade
D = diamond


Design choices made :
	- We can't have duplicate cards in the game.
	- It is possible that no one win a turn (for example : we have 4 players, there is a tiebreak between 2 players and they both run out of cards before we can determine who won the turn. As a result, those 2 players lose the game.). In that case, the pot (cards that were in play) are not given to the remaining players, they are 'lost' for this game.
	- The game can end in a draw if all the players have no more cards.
	- When a player wins a turn, he will earn the pot containing all the cards that were played this turn. Those cards are added in a random order at the bottom of the player deck/hand. 
	- In the game mode where we select the hand of the players :
		- The hands haven’t necessarily the same number of cards between each player. Moreover, we don't have to give all the 52 cards.
		- A player can't be given 0 card (otherwise pseudo dsl craches).
		- The order the cards are given to a player will be maintained (if a player is given 4C 3D, the first card that will be popped from the deck will be the card 4C). The hands are not shuffled at this level.
	- In the game mode where we don't select the hand of the players : 
		- All the cards will be given as fairly as possible between the players. Nonetheless if : (52 % numberOfPlayer != 0), some player will have one more card than other.


In order to test the solution in your own application, connect to the interface IGamingTable. Check GamingTableTest for examples. If you want to test an internal method or classs, add in the csproj the TestClass.

The console application if NOT error proof, if an input is not correct the app will crash.
To convert user input to cards, a proper DSL should be used. 



Example of inputs : 
	- game mode where we select the hand of the players :

1
3
5H 6H 7H 8H
8S 7S 1S 5S
8C 7C 6C 5C


	- game mode where we don't select the hand of the players :

2
5
25