using System;

namespace PokemonDamageCalculator.Models;

//class to represent pokemon stats (base stats, ivs, evs)
public class Stats(int hp, int atk, int def, int spatk, int spdef, int speed)
{
    //create properties
    public int HP { get; set; } = hp;
    public int Atk { get; set; } = atk;
    public int Def { get; set; } = def;
    public int SpAtk { get; set; } = spatk;
    public int SpDef { get; set; } = spdef;
    public int Speed { get; set; } = speed;

    //calculates final stats of pokemon, not including nature
    public static Stats calcFinalStats(int level, Stats basestats, Stats ivs, Stats evs, Nature nature)
    {
        //calc each stat using official formulas
        int hp = ((2 * basestats.HP + ivs.HP + (evs.HP / 4)) * level) / 100 + level + 10;

        int atk = ((2 * basestats.Atk + ivs.Atk + (evs.Atk / 4)) * level) / 100 + 5;

        int def = ((2 * basestats.Def + ivs.Def + (evs.Def / 4)) * level) / 100 + 5;
        
        int spatk = ((2 * basestats.SpAtk + ivs.SpAtk + (evs.SpAtk / 4)) * level) / 100 + 5;
        
        int spdef = ((2 * basestats.SpDef + ivs.SpDef + (evs.SpDef / 4)) * level) / 100 + 5;

        int speed = ((2 * basestats.Speed + ivs.Speed + (evs.Speed / 4)) * level) / 100 + 5;

        //convert enum to int for convenience
        int key = (int)nature;
        
        //natures increase one stat by 10%, decrease another by 10% (except for neutral natures)

        if(key % 6 != 0){ //ignore neutral natures

            //determine which stat is boosted
            if(key < 5) atk = (int)(atk * 1.1);
            else if(key < 10) def = (int)(def * 1.1);
            else if(key < 15) spatk = (int)(spatk * 1.1);
            else if(key < 20) spdef = (int)(spdef * 1.1);
            else speed = (int)(speed * 1.1);

            //determine which stat is decreased
            int i = key % 5;
            if(i == 0) atk = (int)(atk * 0.9);
            else if(i == 1) def = (int)(def * 0.9);
            else if(i == 2) spatk = (int)(spatk * 0.9);
            else if(i == 3) spdef = (int)(spdef * 0.9);
            else speed = (int)(speed * 0.9);
        }

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