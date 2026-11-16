using System.Collections.Generic;

namespace PokemonDamageCalculator.Models;

public class LearnsetDto
{
    public Dictionary<string, List<string>> Learnset { get; set; } = new();
}