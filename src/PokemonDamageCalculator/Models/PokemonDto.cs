using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonDamageCalculator.Models;

public class PokemonDto
{
    public string Name { get; set; } = "";

    public List<string> Types { get; set; } = new();

    [JsonPropertyName("baseStats")]
    public PokemonStatsDto BaseStats { get; set; } = new();

    public bool IsCosmeticForme { get; set; }
}

public class PokemonStatsDto
{
    [JsonPropertyName("hp")]
    public int HP { get; set; }

    [JsonPropertyName("atk")]
    public int Atk { get; set; }

    [JsonPropertyName("def")]
    public int Def { get; set; }

    [JsonPropertyName("spa")]
    public int SpAtk { get; set; }

    [JsonPropertyName("spd")]
    public int SpDef { get; set; }

    [JsonPropertyName("spe")]
    public int Speed { get; set; }
}