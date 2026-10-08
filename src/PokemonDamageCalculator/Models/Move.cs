using System;
using System.Diagnostics.Contracts;

namespace PokemonDamageCalculator.Models;

//class to represent moves and their stats
public class Move(string name, int power, int accuracy, PokemonType type, MoveCategory category)
{
    //create properties
    public string Name { get; private set; } = name;
    public int Power { get; private set; } = power;
    public int Accuracy {get; private set; } = accuracy;
    public PokemonType Type { get; private set; } = type;
    public MoveCategory Category { get; private set; } = category;
}