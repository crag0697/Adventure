using System;
using System.Data;
using System.Numerics;


// Player attributes and functions
public class Style
{
    //-----------------------------------Attributes----------------------------------//
    private int[] _soldier;   // A more direct style focusing on combat
    private int[] _thief;   // A more evasive approach around avoidance and interaction

    //-----------------------------------Constructor----------------------------------//
    public Style()   // Style stats are initialized upon creation of the Style object
    {
        _soldier = new int[] { 4, 1, 15 };
        _thief = new int[] { 1, 5, 10 };
    }

    //------------------------------------Methods-------------------------------------//
    public int[] GetSoldier()   // Get the stats for the soldier
    {
        return _soldier;
    }
    public int[] GetThief()   // Get the stats for the thief
    {
        return _thief;
    }





}