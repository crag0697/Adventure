using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Security.Principal;
using System.Xml.Serialization;

// Player attributes and functions
public class Encounter
{
    //-----------------------------------Attributes----------------------------------//
    private string[] _types = { "combat" };   // A list of encounter types
    private string _title;   // The name of the encounter
    private string _type;  // The chosen type for a current instance of encounter

    //-----------------------------------Constructor----------------------------------//
    public Encounter()   // When an Encounter is created, set the type and title automatically
    {
        Random type_index = new Random();   // Initialize an instance of the Random class
        int i = type_index.Next(0, _types.Length);   // Choose a random type from the list of options
        _type = _types[i];

        if (_type == "combat")
        {
            _title = "knight";
        }
    }

    //------------------------------------Methods-------------------------------------//
    public string GetType()   // Get the encounter type
    {
        return _type;
    }

    public void ShowAttack(int attack_dir)   // Display the direction of an attack to the user
    {
        if (attack_dir == 0)   // The attack direction indicates the direction for a successful defence
        {
            Console.WriteLine("     /");
            Console.WriteLine("    /");
            Console.WriteLine("   /");
            Console.WriteLine("  /");
            Console.WriteLine(" \\");
            Console.WriteLine("/");
        }
        else if (attack_dir == 1)   // The attack direction indicates the direction for a successful defence
        {
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine("---");
            Console.WriteLine(" |");
        }
        else if (attack_dir == 2)   // The attack direction indicates the direction for a successful defence
        {
            Console.WriteLine("    \\     ");
            Console.WriteLine("     \\    ");
            Console.WriteLine("      \\   ");
            Console.WriteLine("       \\  ");
            Console.WriteLine("        \\");
            Console.WriteLine("         /");
            Console.WriteLine("          \\");
        }
    }

    public void RunCombat()   // Function to run a combat encounter
    {
        int[] enemy_stats = { 3, 1, 12 };   // Set the enemy stats, potential to be randomly generated through additonal classes
        string[] atk_points = { "left", "up", "right" };   // Make a list of possible attack directions
        Random enemy_atk = new Random();   // Initialize a random class for choosing the direction of the strike from atk_points
        Console.WriteLine("Press the arrow key for the opposite direction of the strike to block.");

        Thread.Sleep(2000);  // Pause execution for the user to prepare
        
        int attack_dir = enemy_atk.Next(0, atk_points.Length);
        int prev_attack_dir = -1; // Initialize to an invalid index

        int rounds = 0;   // Loop through 3 rounds of attacks allowing the user to block each one
        while (rounds <= 2)
        {
            // Ensure a different attack direction from the previous one so there are no duplicates in a row
            while (attack_dir == prev_attack_dir)
            {
                attack_dir = enemy_atk.Next(0, atk_points.Length);
            }

            Console.WriteLine("Strike!");
            ShowAttack(attack_dir);   // Display the attack to the user

            bool success = Timer(attack_dir);   // Call the timer function to run the encounter

            if (success)   // When the user successfully blocks within the time period display a confirmation message
            {
                Console.WriteLine("Blocked!!");
            }
            else   // When the user fails, display a failure message and end the encounter
            {
                Console.WriteLine("You're hit!!");
                Console.WriteLine("Encounter over!");
                return; // End the game
            }

            Console.WriteLine();
            Console.WriteLine();

            prev_attack_dir = attack_dir; // Update the previous attack direction

            rounds++;   // Increment the number of rounds and pause for the user to prepare
            Thread.Sleep(1000);
        }
    }


    public bool isBlock(int attack, ref int timer)   // Assess if the block was successful
    {
        // Check if any input is available from the user
        if (Console.KeyAvailable)
        {
            // The program will wait for a key input from the user
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (attack == 0 && keyInfo.Key == ConsoleKey.LeftArrow)   // The left arrow key blocks a strike from the right
            {
                return true;   // If the input was correct, it returns true
            }
            else if (attack == 1 && keyInfo.Key == ConsoleKey.DownArrow)   // The down arrow key blocks a strike from the top
            {
                return true;   // If the input was correct, it returns true
            }
            else if (attack == 2 && keyInfo.Key == ConsoleKey.RightArrow)   // The right arrow key blocks a strike from the left
            {
                return true;   // If the input was correct, it returns true
            }
        }
        // Decrement the timer if no input was received
        timer--;
        return false;
    }

public bool Timer(int attack)   // Run the timer loop
    {
        int timer = 2;   // Set the time for the use to react to the output

        while (timer > 0)
        {
            // Check if the correct key is pressed
            if (isBlock(attack, ref timer))
            {
                return true;
            }
            Thread.Sleep(1000);   // Sleep delays execution by n milliseconds functioning as a timer
        }

        return false;   // Returns false if no block was detected in the time limit
    }
}