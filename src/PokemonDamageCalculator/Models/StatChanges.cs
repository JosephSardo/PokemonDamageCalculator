using System;

namespace PokemonDamageCalculator.Models;

//class to represent mid battle stat changes
public class StatChanges
{
    //create properties
    public int Atk {get; set;}
    public int Def {get; set;}
    public int SpAtk {get; set;}
    public int SpDef {get; set;}
    public int Speed {get; set;}

    public StatChanges()
    {
        Atk = 0;
        Def = 0;
        SpAtk = 0;
        SpDef = 0;
        Speed = 0;
    }
}