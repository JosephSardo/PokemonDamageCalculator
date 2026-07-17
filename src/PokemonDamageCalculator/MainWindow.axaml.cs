using Avalonia.Controls;
using PokemonDamageCalculator.Models;
using System;

namespace PokemonDamageCalculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Stats sampleIVs = new Stats(31, 31, 31, 31, 31, 31);
        Stats sampleEVs = new Stats(4, 252, 0, 0, 0, 252);

        Pokemon garchomp = new Pokemon("Garchomp", 50, new Stats(108, 130, 95, 80, 85, 102), sampleIVs, sampleEVs);

        Console.WriteLine("Name: " + garchomp.Name);
        Console.WriteLine("Level: " + garchomp.Level);
        garchomp.printFinalStats();
    }
}