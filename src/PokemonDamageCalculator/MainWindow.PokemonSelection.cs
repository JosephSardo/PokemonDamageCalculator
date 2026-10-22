using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains declarations for all objects necessary for UI to function
public partial class MainWindow
{
    //Pokemon 1 Functions

    //Pokemon selection
    private void Pokemon1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1acb.SelectedItem is Pokemon selectedPokemon)
        {
            Pokemon1 = selectedPokemon;

            BaseHPText1.Text = selectedPokemon.BaseStats.HP.ToString();
            BaseAtkText1.Text = selectedPokemon.BaseStats.Atk.ToString();
            BaseDefText1.Text = selectedPokemon.BaseStats.Def.ToString();
            BaseSpAtkText1.Text = selectedPokemon.BaseStats.SpAtk.ToString();
            BaseSpDefText1.Text = selectedPokemon.BaseStats.SpDef.ToString();
            BaseSpeedText1.Text = selectedPokemon.BaseStats.Speed.ToString();

            //Reset stats
            LevelTextBox1.Text = "50";

            HpIVTextBox1.Text = "31";
            AtkIVTextBox1.Text = "31";
            DefIVTextBox1.Text = "31";
            SpAtkIVTextBox1.Text = "31";
            SpDefIVTextBox1.Text = "31";
            SpeedIVTextBox1.Text = "31";

            HpEVTextBox1.Text = "0";
            AtkEVTextBox1.Text = "0";
            DefEVTextBox1.Text = "0";
            SpAtkEVTextBox1.Text = "0";
            SpDefEVTextBox1.Text = "0";
            SpeedEVTextBox1.Text = "0";

            //Reset moves
            P1move1acb.Text = String.Empty;
            P1move1acb.SelectedItem = null;

            P1move2acb.Text = String.Empty;
            P1move2acb.SelectedItem = null;

            P1move3acb.Text = String.Empty;
            P1move3acb.SelectedItem = null;

            P1move4acb.Text = String.Empty;
            P1move4acb.SelectedItem = null;

            //Reset misc attributes
            Nature1acb.SelectedItem = Nature.Serious;
            Ability1acb.SelectedItem = Pokemon1.Ability; //LATER: Make the pokemon's ability default to its first valid ability upon the pokemon object's creation
            Item1acb.SelectedItem = "None";
            Status1cb.SelectedIndex = 0;
            Gender1cb.SelectedIndex = 0;

            //Reset current HP
            CurrentHPTextBox1.Text = Pokemon1.FinalStats.HP.ToString();
            MaxHPText1.Text = "/" + Pokemon1.FinalStats.HP.ToString() + "   (";
            HpSlider1.Maximum = Pokemon1.FinalStats.HP;
            HpSlider1.Value = Pokemon1.FinalStats.HP;
        }
    }

    //Level selection
    private void LevelTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || LevelTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(LevelTextBox1.Text, out int lvl)) //ensure input is an integer
        {
            if(LevelTextBox1.Text!.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                LevelTextBox1.Text = "";
                return;
            }
            LevelTextBox1.Text = Pokemon1.Level.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedlvl = Math.Clamp(lvl, 1, 100); //ensure input is within valid range

        if(lvl != correctedlvl) //if input wasn't in valid range, correct the textbox
        {
            LevelTextBox1.Text = correctedlvl.ToString();
            return;
        }

        LevelTextBox1.Text = correctedlvl.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeLevel(correctedlvl);

        //update current HP based on new max
        CurrentHPTextBox1.Text = Pokemon1.FinalStats.HP.ToString();
        MaxHPText1.Text = "/" + Pokemon1.FinalStats.HP.ToString() + "   (";
        HpSlider1.Maximum = Pokemon1.FinalStats.HP;
        HpSlider1.Value = Pokemon1.FinalStats.HP;
    }

    //Level selection textbox lost focus handler
    private void LevelTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;

        if(string.IsNullOrWhiteSpace(LevelTextBox1.Text))
        {
            LevelTextBox1.Text = Pokemon1.Level.ToString();
        }
    }
}