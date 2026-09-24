using System;

namespace PokemonDamageCalculator.Models;

//service class to calculate maxiumum possible move damage
public static class DamageCalculator
{
    public static int calcDamage(Pokemon attacker, Pokemon defender, Move move, BattleState battleState)
    {
        int relevantAtk;
        int relevantDef;
        PokemonType moveType = move.Type;

        if(move.Category == MoveCategory.Physical)
        {
            relevantAtk = attacker.FinalStats.Atk;
            relevantDef = defender.FinalStats.Def;
            //determine stat changes
            relevantAtk = (int)(relevantAtk * attacker.getAtkMultiplier());
            relevantDef = (int)(relevantDef * defender.getDefMultiplier());
        } else
        {
            relevantAtk = attacker.FinalStats.SpAtk;
            relevantDef = defender.FinalStats.SpDef;
        }

        //determine if weather affects defensive stats (snow or sand)
        Weather weather = battleState.Weather;

        //sand
        if(weather == Weather.Sand)
        {
            if(move.Category == MoveCategory.Special && //special defense of rock types is buffed in sandstorm
            (defender.Types.Type1 == PokemonType.Rock || (defender.Types.Type2 != null && defender.Types.Type2 == PokemonType.Rock)))
            {
                relevantDef = (int)(relevantDef * 1.5);
            }

            if(move.Name == "Weather Ball")
            {
                moveType = PokemonType.Rock;
            }
        }

        //snow
        if(weather == Weather.Snow)
        {
            if(move.Category == MoveCategory.Physical && //special defense of rock types is buffed in sandstorm
            (defender.Types.Type1 == PokemonType.Ice || (defender.Types.Type2 != null && defender.Types.Type2 == PokemonType.Ice)))
            {
                relevantDef = (int)(relevantDef * 1.5);
            }

            if(move.Name == "Weather Ball")
            {
                moveType = PokemonType.Ice;
            }
        }

        //determine weather ball multiplier
        int effectiveMovePower = move.Power;
        if(move.Name == "Weather Ball" && weather != Weather.None)
        {
            effectiveMovePower *= 2;
        }

        //run official damage formula
        //formula is done in steps to ensure decimal truncation is performed in the correct places
        //double damage = ((((2 * attacker.Level / 5) + 2) * move.Power * relevantAtk / relevantDef) / 50) + 2;

        int damage = (2 * attacker.Level) / 5;
        damage += 2;
        damage *= effectiveMovePower;
        damage *= (int)relevantAtk;
        damage /= (int)relevantDef;
        damage /= 50;
        damage += 2;

        //determine if weather affects damage (sun or rain)
        //sun
        if(weather == Weather.Sun || weather == Weather.HSun)
        {
            if(moveType == PokemonType.Fire) //any sun boosts fire attacks
            {
                damage = (int)(damage * 1.5);
            } else if(moveType == PokemonType.Water) //regular sun halves water attacks
            {
                damage = (int)(damage * 0.5);
                if(weather == Weather.HSun) //extremely harsh sun negates water attacks
                {
                    return 0;
                }
            }

            if(move.Name == "Weather Ball")
            {
                moveType = PokemonType.Fire;
            }
        }

        //rain
        if(weather == Weather.Rain || weather == Weather.HRain)
        {
            if(moveType == PokemonType.Water) //any rain boosts water attacks
            {
                damage = (int)(damage * 1.5);
            } else if(moveType == PokemonType.Fire) //any rain halves fire attacks
            {
                damage = (int)(damage * 0.5);
            }

            if(move.Name == "Solar Beam" || move.Name == "Solar Blade") //special case: these 2 moves are nerfed by rain
            {
                damage = (int)(damage * 0.5);
            }

            if(move.Name == "Weather Ball")
            {
                moveType = PokemonType.Water;
            }
        }

        //determine STAB bonus
        if(moveType == attacker.Types.Type1 || (attacker.Types.Type2 != null && moveType == attacker.Types.Type2))
        {
            damage = (int)(damage * 1.5);
        }

        //determine type matchup
        damage = (int)(damage * TypeChart.getEffectiveness(move.Type, defender.Types.Type1));
        if(defender.Types.Type2 != null) //check if the pokemon has a second type before determining its matchup
        {
            damage = (int)(damage * TypeChart.getEffectiveness(move.Type, (PokemonType)defender.Types.Type2));
        }

        return damage;
    }
}