using System;
using System.Data;
using System.Numerics;

// Player attributes and functions
public class Game
{
    //-----------------------------------Attributes----------------------------------//
    private Encounter _encounter;

    //------------------------------------Methods-------------------------------------//
    public Encounter GetEncounter()   // Getter for the encounter object
    {
        return _encounter;
    }

    public void RunEncounter()   // Run an encounter type
    {
        _encounter = new Encounter();
        if (_encounter.GetType() == "combat")
        {
            _encounter.RunCombat();
        }
    }






    





}