using System;
using System.Diagnostics.Contracts;

namespace PokemonDamageCalculator.Models;

//class to represent moves and their stats
public class Move
{
    //create properties
    public string Name {get; private set;} = "";
    public int Power {get; private set;}
    public PokemonType Type {get; private set;}
    public MoveCategory Category {get; private set;}

    public Move(string name, int power, PokemonType type, MoveCategory category)
    {
        Name = name;
        Power = power;
        Type = type;
        Category = category;
    }
}