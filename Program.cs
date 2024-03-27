using System;
using System.Data;
using System.Numerics;

// Main Program to run the game
public class Program
{
    static void Main(string[] args)
    {
        // Create a new player
        Player player1 = new Player();
        player1.SetName();
        player1.SetStyle();
        player1.SetStats();

        // Show the player character for the adventure
        player1.DisplayCharacter();

        // create a new game
        Game game = new Game();

        // Story strings leading to encounters for the user

        // Run an encounter
        game.RunEncounter();
    }
}