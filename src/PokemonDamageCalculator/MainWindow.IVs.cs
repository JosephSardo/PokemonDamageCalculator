using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains code for IV selection
public partial class MainWindow
{
    //Pokemon 1 functions
    
    //Change IVs
    private void HpIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || HpIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(HpIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(HpIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                HpIVTextBox1.Text = "";
                return;
            }
            HpIVTextBox1.Text = Pokemon1.IVs.HP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            HpIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        HpIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeHPIV(correctedIV);
    }

    private void AtkIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || AtkIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(AtkIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(AtkIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                AtkIVTextBox1.Text = "";
                return;
            }
            AtkIVTextBox1.Text = Pokemon1.IVs.Atk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            AtkIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        AtkIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeAtkIV(correctedIV);
    }

    private void DefIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || DefIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(DefIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(DefIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                DefIVTextBox1.Text = "";
                return;
            }
            DefIVTextBox1.Text = Pokemon1.IVs.Def.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            DefIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        DefIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeDefIV(correctedIV);
    }

    private void SpAtkIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || SpAtkIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpAtkIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(SpAtkIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpAtkIVTextBox1.Text = "";
                return;
            }
            SpAtkIVTextBox1.Text = Pokemon1.IVs.SpAtk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpAtkIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        SpAtkIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeSpAtkIV(correctedIV);
    }

    private void SpDefIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || SpDefIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpDefIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(SpDefIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpDefIVTextBox1.Text = "";
                return;
            }
            SpDefIVTextBox1.Text = Pokemon1.IVs.SpDef.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpDefIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        SpDefIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeSpDefIV(correctedIV);
    }

    private void SpeedIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || SpeedIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpeedIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(SpeedIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpeedIVTextBox1.Text = "";
                return;
            }
            SpeedIVTextBox1.Text = Pokemon1.IVs.Speed.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpeedIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        SpeedIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeSpeedIV(correctedIV);
    }

    //_________________________________________________________________________________________________________________________________________________________________________________________
    //Lost focus events
    private void HpIVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(HpIVTextBox1.Text))
        {
            HpIVTextBox1.Text = Pokemon1.IVs.HP.ToString();
        }
    }

    private void AtkIVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(AtkIVTextBox1.Text))
        {
            AtkIVTextBox1.Text = Pokemon1.IVs.Atk.ToString();
        }
    }

    private void DefIVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(DefIVTextBox1.Text))
        {
            DefIVTextBox1.Text = Pokemon1.IVs.Def.ToString();
        }
    }

    private void SpAtkIVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(SpAtkIVTextBox1.Text))
        {
            SpAtkIVTextBox1.Text = Pokemon1.IVs.SpAtk.ToString();
        }
    }

    private void SpDefIVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(SpDefIVTextBox1.Text))
        {
            SpDefIVTextBox1.Text = Pokemon1.IVs.SpDef.ToString();
        }
    }

    private void SpeedIVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(SpeedIVTextBox1.Text))
        {
            SpeedIVTextBox1.Text = Pokemon1.IVs.Speed.ToString();
        }
    }
}