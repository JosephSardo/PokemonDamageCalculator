using System;

namespace PokemonDamageCalculator.Models;

//class to represent pokemon stats (base stats, ivs, evs)
public class Stats
{
    //create properties
    public int HP {get; set;}
    public int Atk {get; set;}
    public int Def {get; set;}
    public int SpAtk {get; set;}
    public int SpDef {get; set;}
    public int Speed {get; set;}

    public Stats(int hp, int atk, int def, int spatk, int spdef, int speed)
    {
        HP = hp;
        Atk = atk;
        Def = def;
        SpAtk = spatk;
        SpDef = spdef;
        Speed = speed;
    }

    //calculates final stats of pokemon, not including nature
    public static Stats calcFinalStats(int level, Stats basestats, Stats ivs, Stats evs)
    {
        //calc each stat using official formulas
        int hp = ((2 * basestats.HP + ivs.HP + (evs.HP / 4)) * level) / 100 + level + 10;

        int atk = (((2 * basestats.Atk + ivs.Atk + (evs.Atk / 4)) * level) / 100 + 5) * 1;

        int def = (((2 * basestats.Def + ivs.Def + (evs.Def / 4)) * level) / 100 + 5) * 1;
        
        int spatk = (((2 * basestats.SpAtk + ivs.SpAtk + (evs.SpAtk / 4)) * level) / 100 + 5) * 1;
        
        int spdef = (((2 * basestats.SpDef + ivs.SpDef + (evs.SpDef / 4)) * level) / 100 + 5) * 1;

        int speed = (((2 * basestats.Speed + ivs.Speed + (evs.Speed / 4)) * level) / 100 + 5) * 1;

        return new Stats(hp, atk, def, spatk, spdef, speed);
    }

    public void print()
    {
        Console.WriteLine("HP: \t" + HP);
        Console.WriteLine("Atk: \t" + Atk);
        Console.WriteLine("Def: \t" + Def);
        Console.WriteLine("SpAtk: \t" + SpAtk);
        Console.WriteLine("SpDef: \t" + SpDef);
        Console.WriteLine("Speed: \t" + Speed);
    }
}

//FOR LATER: Store each nature as a global constant Stats object where each stat is either 10, 11, or 9 so we can cast it to a float and divide by 10 to act as multiplier