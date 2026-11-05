using Avalonia.Controls;
using Avalonia.Interactivity;
using PokemonDamageCalculator.Models;
using System;

namespace PokemonDamageCalculator.Views;

//This mainwindow file contains code for IV selection
public partial class PokemonPanel : UserControl
{   
    //Change IVs
    private void HpIVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || HpIVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(HpIVTextBox.Text, out int IV)) //ensure input is an integer
        {
            if(HpIVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                HpIVTextBox.Text = "";
                return;
            }
            HpIVTextBox.Text = Pokemon.IVs.HP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            HpIVTextBox.Text = correctedIV.ToString();
            return;
        }

        HpIVTextBox.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeHPIV(correctedIV);

        //update current HP based on new max
        CurrentHPTextBox.Text = Pokemon.FinalStats.HP.ToString(); 
        MaxHPText.Text = "/" + Pokemon.FinalStats.HP.ToString() + "   (";
        HpSlider.Maximum = Pokemon.FinalStats.HP;
        HpSlider.Value = Pokemon.FinalStats.HP;
    }

    private void AtkIVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || AtkIVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(AtkIVTextBox.Text, out int IV)) //ensure input is an integer
        {
            if(AtkIVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                AtkIVTextBox.Text = "";
                return;
            }
            AtkIVTextBox.Text = Pokemon.IVs.Atk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            AtkIVTextBox.Text = correctedIV.ToString();
            return;
        }

        AtkIVTextBox.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeAtkIV(correctedIV);
    }

    private void DefIVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || DefIVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(DefIVTextBox.Text, out int IV)) //ensure input is an integer
        {
            if(DefIVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                DefIVTextBox.Text = "";
                return;
            }
            DefIVTextBox.Text = Pokemon.IVs.Def.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            DefIVTextBox.Text = correctedIV.ToString();
            return;
        }

        DefIVTextBox.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeDefIV(correctedIV);
    }

    private void SpAtkIVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || SpAtkIVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpAtkIVTextBox.Text, out int IV)) //ensure input is an integer
        {
            if(SpAtkIVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpAtkIVTextBox.Text = "";
                return;
            }
            SpAtkIVTextBox.Text = Pokemon.IVs.SpAtk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpAtkIVTextBox.Text = correctedIV.ToString();
            return;
        }

        SpAtkIVTextBox.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeSpAtkIV(correctedIV);
    }

    private void SpDefIVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || SpDefIVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpDefIVTextBox.Text, out int IV)) //ensure input is an integer
        {
            if(SpDefIVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpDefIVTextBox.Text = "";
                return;
            }
            SpDefIVTextBox.Text = Pokemon.IVs.SpDef.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpDefIVTextBox.Text = correctedIV.ToString();
            return;
        }

        SpDefIVTextBox.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeSpDefIV(correctedIV);
    }

    private void SpeedIVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || SpeedIVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpeedIVTextBox.Text, out int IV)) //ensure input is an integer
        {
            if(SpeedIVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpeedIVTextBox.Text = "";
                return;
            }
            SpeedIVTextBox.Text = Pokemon.IVs.Speed.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpeedIVTextBox.Text = correctedIV.ToString();
            return;
        }

        SpeedIVTextBox.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeSpeedIV(correctedIV);
    }

    //_________________________________________________________________________________________________________________________________________________________________________________________
    //Lost focus events
    private void HpIVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(HpIVTextBox.Text))
        {
            HpIVTextBox.Text = Pokemon.IVs.HP.ToString();
        }
    }

    private void AtkIVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(AtkIVTextBox.Text))
        {
            AtkIVTextBox.Text = Pokemon.IVs.Atk.ToString();
        }
    }

    private void DefIVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(DefIVTextBox.Text))
        {
            DefIVTextBox.Text = Pokemon.IVs.Def.ToString();
        }
    }

    private void SpAtkIVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(SpAtkIVTextBox.Text))
        {
            SpAtkIVTextBox.Text = Pokemon.IVs.SpAtk.ToString();
        }
    }

    private void SpDefIVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(SpDefIVTextBox.Text))
        {
            SpDefIVTextBox.Text = Pokemon.IVs.SpDef.ToString();
        }
    }

    private void SpeedIVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(SpeedIVTextBox.Text))
        {
            SpeedIVTextBox.Text = Pokemon.IVs.Speed.ToString();
        }
    }
}