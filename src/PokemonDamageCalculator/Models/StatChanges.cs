using System;

namespace PokemonDamageCalculator.Models;

//class to represent mid battle stat changes
//stat changes are integers between -6 and +6, inclusive
public class StatChanges()
{
    //create properties
    public int Atk {get; private set;} = 0;
    public int Def {get; private set;} = 0;
    public int SpAtk {get; private set;} = 0;
    public int SpDef {get; private set;} = 0;
    public int Speed {get; private set;} = 0;

    //Stat changes alter the numerator or denominator of the fraction 2/2
    //positive changes increase the numerator, negative changes increase the denominator
    //eg. a +2 stat will make the fraction 4/2 for a 2x multiplier
    //however, a -2 stat will make the fraction 2/4 for a 0.5x multiplier
    public double getAtkMultiplier()
    {
        if(Atk > 0)
        {
            return (2 + Atk)/2;
        } else if(Atk < 0)
        {
            return 2/(2 - Atk);
        }

        return 1; //if no stat change, return 1x multiplier
    }

    public double getDefMultiplier()
    {
        if(Def > 0)
        {
            return (2 + Def)/2;
        } else if(Def < 0)
        {
            return 2/(2 - Def);
        }

        return 1; //if no stat change, return 1x multiplier
    }

    public double getSpAtkMultiplier()
    {
        if(SpAtk > 0)
        {
            return (2 + SpAtk)/2;
        } else if(SpAtk < 0)
        {
            return 2/(2 - SpAtk);
        }

        return 1; //if no stat change, return 1x multiplier
    }

    public double getSpDefMultiplier()
    {
        if(SpDef > 0)
        {
            return (2 + SpDef)/2;
        } else if(SpDef < 0)
        {
            return 2/(2 - SpDef);
        }

        return 1; //if no stat change, return 1x multiplier
    }

    public double getSpeedMultiplier()
    {
        if(Speed > 0)
        {
            return (2 + Speed)/2;
        } else if(Speed < 0)
        {
            return 2/(2 - Speed);
        }

        return 1; //if no stat change, return 1x multiplier
    }

    //setters
    public void changeAtk(int atk)
    {
        if(atk > 6) atk = 6;
        else if(atk < -6) atk = -6;

        Atk = atk;
    }

    public void changeDef(int def)
    {
        if(def > 6) def = 6;
        else if(def < -6) def = -6;

        Def = def;
    }

    public void changeSpAtk(int spatk)
    {
        if(spatk > 6) spatk = 6;
        else if(spatk < -6) spatk = -6;

        SpAtk = spatk;
    }

    public void changeSpDef(int spdef)
    {
        if(spdef > 6) spdef = 6;
        else if(spdef < -6) spdef = -6;

        SpDef = spdef;
    }

    public void changeSpeed(int speed)
    {
        if(speed > 6) speed = 6;
        else if(speed < -6) speed = -6;

        Speed = speed;
    }
}