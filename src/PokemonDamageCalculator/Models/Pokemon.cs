using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace PokemonDamageCalculator.Models;

//class to represent pokemon and their names, levels, base stats
public class Pokemon
{
    //create properties
    //base stats, ivs, and evs are still stored even though we store the final stats bc the final stats should be dynamically updatable
    public string Name {get; set;} = "";
    public int Level {get; set;}
    public int CurrentHP {get; set;} //Stat objects store max hp. This int stores current hp

    public Stats BaseStats {get; set;}
    public Stats IVs {get; set;}
    public Stats EVs {get; set;}
    public Stats FinalStats {get; set;}

    public (PokemonType Type1, PokemonType? Type2) Types {get; set;} //second type is nullable bc not all pokemon have 2 types
    public Nature Nature {get; set;}
    public StatusCondition Status {get; set;}

    public Pokemon(string name, Stats basestats, PokemonType type1, PokemonType type2)
    {
        Name = name;
        Level = 50;

        BaseStats = basestats;
        IVs = new Stats(31, 31, 31, 31, 31, 31);    //default perfect IVS
        EVs = new Stats(0, 0, 0, 0, 0, 0);          //default no EVs
        Nature = Nature.Serious;                    //default neutral nature
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //calculates final stats of pokemon, not including nature

        CurrentHP = FinalStats.HP;
        Types = (type1, type2);
        Status = StatusCondition.None;  //default no status
    }

    //print IVs
    public void printIVs()
    {
        IVs.print();
    }

    //print EVs
    public void printEVs()
    {
        EVs.print();
    }

    //print final stats
    public void printFinalStats()
    {
        FinalStats.print();
    }

    //update level
    public void changeLevel(int level)
    {
        if(level < 1) level = 1;
        else if(level > 100) level = 100;

        Level = level;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update nature
    public void changeNature(Nature nature)
    {
        Nature = nature;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //ev total can't surpass 510
    public int calcEVTotal()
    {
        return EVs.HP + EVs.Atk + EVs.Def + EVs.SpAtk + EVs.SpDef + EVs.Speed;
    }

    //update IVs
    //update hp iv
    public void changeHPIV(int iv)
    {
        if(iv > 31) iv = 31;
        else if(iv < 0) iv = 0;

        IVs.HP = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update atk iv
    public void changeAtkIV(int iv)
    {
        if(iv > 31) iv = 31;
        else if(iv < 0) iv = 0;

        IVs.Atk = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update def iv
    public void changeDefIV(int iv)
    {
        if(iv > 31) iv = 31;
        else if(iv < 0) iv = 0;

        IVs.Def = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update spatk iv
    public void changeSpAtkIV(int iv)
    {
        if(iv > 31) iv = 31;
        else if(iv < 0) iv = 0;

        IVs.SpAtk = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update spdef iv
    public void changeSpDefIV(int iv)
    {
        if(iv > 31) iv = 31;
        else if(iv < 0) iv = 0;

        IVs.SpDef = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update speed iv
    public void changeSpeedIV(int iv)
    {
        if(iv > 31) iv = 31;
        else if(iv < 0) iv = 0;

        IVs.Speed = iv;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update EVs
    //update hp ev
    public void changeHPEV(int ev)
    {
        if(ev < 0) ev = 0;
        else if (ev > 252) ev = 252;

        if(calcEVTotal() - EVs.HP + ev > 510) //check if the change puts the EV total over the 510 limit
        {
            ev = 510 - (calcEVTotal() - EVs.HP);
        }

        EVs.HP = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update atk ev
    public void changeAtkEV(int ev)
    {
        if(ev < 0) ev = 0;
        else if (ev > 252) ev = 252;

        if(calcEVTotal() - EVs.Atk + ev > 510) //check if the change puts the EV total over the 510 limit
        {
            ev = 510 - (calcEVTotal() - EVs.Atk);
        }

        EVs.Atk = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update def ev
    public void changeDefEV(int ev)
    {
        if(ev < 0) ev = 0;
        else if (ev > 252) ev = 252;

        if(calcEVTotal() - EVs.Def + ev > 510) //check if the change puts the EV total over the 510 limit
        {
            ev = 510 - (calcEVTotal() - EVs.Def);
        }

        EVs.Def = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update spatk ev
    public void changeSpAtkEV(int ev)
    {
        if(ev < 0) ev = 0;
        else if (ev > 252) ev = 252;

        if(calcEVTotal() - EVs.SpAtk + ev > 510) //check if the change puts the EV total over the 510 limit
        {
            ev = 510 - (calcEVTotal() - EVs.SpAtk);
        }

        EVs.SpAtk = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update spdef ev
    public void changeSpDefEV(int ev)
    {
        if(ev < 0) ev = 0;
        else if (ev > 252) ev = 252;

        if(calcEVTotal() - EVs.SpDef + ev > 510) //check if the change puts the EV total over the 510 limit
        {
            ev = 510 - (calcEVTotal() - EVs.SpDef);
        }

        EVs.SpDef = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    //update speed ev
    public void changeSpeedEV(int ev)
    {
        if(ev < 0) ev = 0;
        else if (ev > 252) ev = 252;

        if(calcEVTotal() - EVs.Speed + ev > 510) //check if the change puts the EV total over the 510 limit
        {
            ev = 510 - (calcEVTotal() - EVs.Speed);
        }

        EVs.Speed = ev;
        FinalStats = Stats.calcFinalStats(Level, BaseStats, IVs, EVs, Nature); //update final stats
    }

    /*

    Self note: Values can be accessed like this:
    Console.WriteLine(pikachu.Stats.Atk);
    Console.WriteLine(pikachu.Level);

    */

}