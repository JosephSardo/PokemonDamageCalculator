namespace PokemonDamageCalculator.Models;

public class MoveDto
{
    public string Name {get; set;} = "";
    public string Type {get; set;} = "";
    public int? BasePower {get; set;}
    public int? Accuracy {get; set;}
    public string Category {get; set;} = "";
}