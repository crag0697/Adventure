using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Security.Principal;
using System.Xml.Serialization;

// Player attributes and functions
public class Player
{
    //-----------------------------------Attributes----------------------------------//
    private string _name;   //Players may choose their name
    private string _style;   // Players choose a fighting style or role which is its own class object
    private int[] _stats;   // Track the player stats for combat purposes

    //------------------------------------Methods-------------------------------------//
    public void SetName()   // Set the player name
    {
        Console.Write("Please enter your name: ");
        _name = Console.ReadLine();
    }
    public string GetName()   // Get the player name
    {
        return _name;
    }

    public void SetStyle()   // Set the player fighting style
    {
        string role = "";
        do
        {
            Console.Write("Choose your fighting style, 'Soldier' or 'Thief': ");  // Player chooses a playstyle correlating to future encounters
            role = Console.ReadLine();
            if (role.ToLower() != "soldier" && role.ToLower() != "thief")
            {
                Console.WriteLine("Improper entry, Please enter a valid choice for your style.");   // The player must entera  valid playstyle
            }
        }
        while (role.ToLower() != "soldier" && role.ToLower() != "thief");
        _style = role;
    }
    public string GetStyle()   // Get the player style
    {
        return _style;
    }

    public void SetStats()   // Set the stats for the player based on the fighting style
    {
        Style style = new Style();  // Create a style object which is preinitialized with stats

        if (_style == "soldier")
        {
            _stats = style.GetSoldier();  
        }
        else if (_style == "thief")
        {
            _stats = style.GetThief();
        }
    }
    public int[] GetStats()   // Access the stats for judging encounter resolution in further implementation
    {
        return _stats;
    }

    public void DisplayCharacter()   // Display the player's character bio
    {
        Console.WriteLine("Player Character: ");
        Console.WriteLine($"Name: {GetName()} - {GetStyle()}");
        Console.WriteLine($"Strength: {GetStats()[0]} | Agility: {GetStats()[1]} | HP: {GetStats()[2]}");
    }

}