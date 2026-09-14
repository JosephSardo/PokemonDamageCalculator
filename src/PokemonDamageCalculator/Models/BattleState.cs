using System;
using System.Diagnostics.Contracts;

namespace PokemonDamageCalculator.Models;

//class to represent current field conditions
public class BattleState
{
    //create properties
    public Weather Weather {get; set;}
    public Terrain Terrain {get; set;}

    //note: screens don't stack with aurora veil
    //only determines whether the OPPONENT has reflect/light screen/veil
    public Boolean Reflect {get; set;}
    public Boolean LightScreen {get; set;}
    public Boolean AuroraVeil {get; set;}

    public BattleState()
    {
        Weather = Weather.None;
        Terrain = Terrain.None;
        Reflect = false;
        LightScreen = false;
        AuroraVeil = false;
    }
}