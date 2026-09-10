using Avalonia.Controls;
using PokemonDamageCalculator.Models;
using System;

namespace PokemonDamageCalculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Pokemon garchomp = new Pokemon("Garchomp", new Stats(108, 130, 95, 80, 85, 102), PokemonType.Dragon, PokemonType.Ground);
        Console.WriteLine("Made Garchomp");
        garchomp.changeAtkEV(252);
        garchomp.changeSpeedEV(252);
        garchomp.changeHPEV(6);
        garchomp.changeNature(Nature.Adamant);
        Console.WriteLine("Made Garchomp EV Spread");

        Pokemon aggron = new Pokemon("Aggron", new Stats(70, 110, 180, 60, 60, 50), PokemonType.Steel, PokemonType.Rock);
        Console.WriteLine("Made Aggron");
        aggron.changeDefEV(252);
        aggron.changeHPEV(252);
        aggron.changeAtkEV(6);
        aggron.changeNature(Nature.Impish);
        Console.WriteLine("Made Aggron EV Spread");

        /*Console.WriteLine("Garchomp Stats: ");
        Console.WriteLine("Name: " + garchomp.Name);
        Console.WriteLine("Level: " + garchomp.Level);
        garchomp.printFinalStats();

        Console.WriteLine("");

        Console.WriteLine("Aggron Stats: ");
        Console.WriteLine("Name: " + aggron.Name);
        Console.WriteLine("Level: " + aggron.Level);
        aggron.printFinalStats();*/
    }
}