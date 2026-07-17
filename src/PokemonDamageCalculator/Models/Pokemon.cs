using System;
using System.Diagnostics.Contracts;

namespace PokemonDamageCalculator.Models;

//class to represent pokemon and their names, levels, base stats
public class Pokemon
{
    //create properties
    //base stats, ivs, and evs are still stored even though we store the final stats bc the final stats should be dynamically updatable
    public string Name {get; set;} = "";
    public int Level {get; set;}
    public Stats BaseStats {get; set;}
    public Stats IVs {get; set;}
    public Stats EVs {get; set;}
    public Stats FinalStats {get; set;}

    //constructor
    public Pokemon(string name, int level, Stats basestats, Stats ivs, Stats evs)
    {
        Name = name;
        Level = level;
        BaseStats = basestats;
        IVs = ivs;
        EVs = evs;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs); //calculates final stats of pokemon, not including nature
    }

    //print final stats
    public void printFinalStats()
    {
        FinalStats.print();
    }

    //update level
    public void changeLevel(int level)
    {
        Level = level;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update IVs
    //update hp iv
    public void changeHPIV(int iv)
    {
        IVs.HP = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update atk iv
    public void changeAtkIV(int iv)
    {
        IVs.Atk = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update def iv
    public void changeDefIV(int iv)
    {
        IVs.Def = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update spatk iv
    public void changeSpAtkIV(int iv)
    {
        IVs.SpAtk = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update spdef iv
    public void changeSpDefIV(int iv)
    {
        IVs.SpDef = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update speed iv
    public void changeSpeedIV(int iv)
    {
        IVs.Speed = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update EVs
    //update hp ev
    public void changeHPEV(int ev)
    {
        EVs.HP = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update atk ev
    public void changeAtkEV(int ev)
    {
        EVs.Atk = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update def ev
    public void changeDefEV(int ev)
    {
        EVs.Def = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update spatk ev
    public void changeSpAtkEV(int ev)
    {
        EVs.SpAtk = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update spdef ev
    public void changeSpDefEV(int ev)
    {
        EVs.SpDef = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    //update speed ev
    public void changeSpeedEV(int ev)
    {
        EVs.Speed = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, EVs, IVs); //update final stats
    }

    /*

    Note: values can be accessed like this:
    Console.WriteLine(pikachu.Stats.Atk);
    Console.WriteLine(pikachu.Level);

    */

}