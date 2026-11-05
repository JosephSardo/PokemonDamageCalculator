using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator.Views;

//This mainwindow file contains declarations for all objects necessary for UI to function
public partial class PokemonPanel : UserControl
{
    //Pokemon selection
    private void PokemonAcb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(PokemonAcb.SelectedItem is Pokemon selectedPokemon)
        {
            Pokemon = selectedPokemon;

            BaseHPText.Text = selectedPokemon.BaseStats.HP.ToString();
            BaseAtkText.Text = selectedPokemon.BaseStats.Atk.ToString();
            BaseDefText.Text = selectedPokemon.BaseStats.Def.ToString();
            BaseSpAtkText.Text = selectedPokemon.BaseStats.SpAtk.ToString();
            BaseSpDefText.Text = selectedPokemon.BaseStats.SpDef.ToString();
            BaseSpeedText.Text = selectedPokemon.BaseStats.Speed.ToString();

            //Reset stats
            LevelTextBox.Text = "50";

            HpIVTextBox.Text = "31";
            AtkIVTextBox.Text = "31";
            DefIVTextBox.Text = "31";
            SpAtkIVTextBox.Text = "31";
            SpDefIVTextBox.Text = "31";
            SpeedIVTextBox.Text = "31";

            HpEVTextBox.Text = "0";
            AtkEVTextBox.Text = "0";
            DefEVTextBox.Text = "0";
            SpAtkEVTextBox.Text = "0";
            SpDefEVTextBox.Text = "0";
            SpeedEVTextBox.Text = "0";

            //Reset moves
            Move1Acb.Text = String.Empty;
            Move1Acb.SelectedItem = null;

            Move2Acb.Text = String.Empty;
            Move2Acb.SelectedItem = null;

            Move3Acb.Text = String.Empty;
            Move3Acb.SelectedItem = null;

            Move4Acb.Text = String.Empty;
            Move4Acb.SelectedItem = null;

            //Reset misc attributes
            NatureAcb.SelectedItem = Nature.Serious;
            AbilityAcb.SelectedItem = Pokemon.Ability; //LATER: Make the pokemon's ability default to its first valid ability upon the pokemon object's creation
            ItemAcb.SelectedItem = "None";
            StatusCb.SelectedIndex = 0;
            GenderCb.SelectedIndex = 0;

            //Reset current HP
            CurrentHPTextBox.Text = Pokemon.FinalStats.HP.ToString();
            MaxHPText.Text = "/" + Pokemon.FinalStats.HP.ToString() + "   (";
            HpSlider.Maximum = Pokemon.FinalStats.HP;
            HpSlider.Value = Pokemon.FinalStats.HP;
        }
    }

    //Level selection
    private void LevelTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || LevelTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(LevelTextBox.Text, out int lvl)) //ensure input is an integer
        {
            if(LevelTextBox.Text!.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                LevelTextBox.Text = "";
                return;
            }
            LevelTextBox.Text = Pokemon.Level.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedlvl = Math.Clamp(lvl, 1, 100); //ensure input is within valid range

        if(lvl != correctedlvl) //if input wasn't in valid range, correct the textbox
        {
            LevelTextBox.Text = correctedlvl.ToString();
            return;
        }

        LevelTextBox.Text = correctedlvl.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeLevel(correctedlvl);

        //update current HP based on new max
        CurrentHPTextBox.Text = Pokemon.FinalStats.HP.ToString();
        MaxHPText.Text = "/" + Pokemon.FinalStats.HP.ToString() + "   (";
        HpSlider.Maximum = Pokemon.FinalStats.HP;
        HpSlider.Value = Pokemon.FinalStats.HP;
    }

    //Level selection textbox lost focus handler
    private void LevelTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;

        if(string.IsNullOrWhiteSpace(LevelTextBox.Text))
        {
            LevelTextBox.Text = Pokemon.Level.ToString();
        }
    }
}