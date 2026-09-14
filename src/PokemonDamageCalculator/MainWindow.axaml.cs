using Avalonia.Controls;
using PokemonDamageCalculator.Models;
using System;

namespace PokemonDamageCalculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Pokemon Garchomp = new("Garchomp", new Stats(108, 130, 95, 80, 85, 102), PokemonType.Dragon, PokemonType.Ground);
        Console.WriteLine("Made Garchomp");
        Garchomp.changeAtkEV(252);
        Garchomp.changeSpeedEV(252);
        Garchomp.changeHPEV(6);
        Garchomp.changeNature(Nature.Adamant);
        Console.WriteLine("Made Garchomp EV Spread");

        Pokemon Aggron = new("Aggron", new Stats(70, 110, 180, 60, 60, 50), PokemonType.Steel, PokemonType.Rock);
        Console.WriteLine("Made Aggron");
        Aggron.changeDefEV(252);
        Aggron.changeHPEV(252);
        Aggron.changeAtkEV(6);
        Aggron.changeNature(Nature.Impish);
        Console.WriteLine("Made Aggron EV Spread");

        /*Console.WriteLine("Garchomp Stats: ");
        Console.WriteLine("Name: " + Garchomp.Name);
        Console.WriteLine("Level: " + Garchomp.Level);
        Garchomp.printFinalStats();

        Console.WriteLine("");

        Console.WriteLine("Aggron Stats: ");
        Console.WriteLine("Name: " + Aggron.Name);
        Console.WriteLine("Level: " + Aggron.Level);
        Aggron.printFinalStats();*/

        //testing attack calculation
        //assume garchomp is attacker

        BattleState BattleState = new();

        //Test: no stab or type advantage/disadvantage
        Move FireFang = new("Fire Fang", 65, PokemonType.Fire, MoveCategory.Physical);
        int ffdmg = DamageCalculator.calcDamage(Garchomp, Aggron, FireFang, BattleState);
        Console.WriteLine("Fire Fang Damage: " + ffdmg);

        //Test: stab, no type advantage/disadvantage
        Move DragonClaw = new("Dragon Claw", 80, PokemonType.Dragon, MoveCategory.Physical);
        int dcdmg = DamageCalculator.calcDamage(Garchomp, Aggron, DragonClaw, BattleState);
        Console.WriteLine("Dragon Claw Damage: " + dcdmg);
    }
}

/*
Garchomp Set: (for testing)

Garchomp @ Loaded Dice
Ability: Rough Skin
Level: 50
Tera Type: Fire
EVs: 6 HP / 252 Atk / 252 Spe
Adamant Nature
- Dragon Claw
- Earthquake
- Fire Fang
- Swords Dance

Aggron Set:

Aggron @ Aggronite
Ability: Strong Jaw
Level: 50
EVs: 252 HP / 6 Atk / 252 Def
Impish Nature
- Body Press
- Toxic
- Heavy Slam
- Stealth Rock
*/