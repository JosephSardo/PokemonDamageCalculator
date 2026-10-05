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
    public Boolean Pkm1Reflect {get; set;}
    public Boolean Pkm1LightScreen {get; set;}
    public Boolean Pkm1AuroraVeil {get; set;}

    public Boolean Pkm2Reflect {get; set;}
    public Boolean Pkm2LightScreen {get; set;}
    public Boolean Pkm2AuroraVeil {get; set;}

    public BattleState()
    {
        Weather = Weather.None;
        Terrain = Terrain.None;

        Pkm1Reflect = false;
        Pkm1LightScreen = false;
        Pkm1AuroraVeil = false;

        Pkm2Reflect = false;
        Pkm2LightScreen = false;
        Pkm2AuroraVeil = false;
    }
}