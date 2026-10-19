using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains functions to allow for alteration of CURRENT hp (NOT the hp stat)
public partial class MainWindow
{
    //Change exact current HP
    private void CurrentHPTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || CurrentHPTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(CurrentHPTextBox1.Text, out int HP)) //ensure input is an integer
        {
            if(CurrentHPTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                CurrentHPTextBox1.Text = "";
                return;
            }
            CurrentHPTextBox1.Text = Pokemon1.currentHP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same HP remains displayed
            return;
        }

        int correctedHP = Math.Clamp(HP, 0, Pokemon1.FinalStats.HP); //ensure input is within valid range

        if(HP != correctedHP) //if input wasn't in valid range, correct the textbox
        {
            CurrentHPTextBox1.Text = correctedHP.ToString();
            return;
        }

        CurrentHPTextBox1.Text = correctedHP.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.currentHP = correctedHP;
        HpSlider1.Value = correctedHP;
        
        //Update percentage HP display
        int currentPerc = (int)(Pokemon1.currentHP / Pokemon1.FinalStats.HP * 100);
        PercHPTextBox1.Text = currentPerc.ToString();
    }

    //Change percent current HP
    private void PercHPTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || PercHPTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        int currentPerc = (int)(Pokemon1.currentHP / Pokemon1.FinalStats.HP * 100); //current HP percentage

        if(!int.TryParse(PercHPTextBox1.Text, out int HPperc)) //ensure input is an integer
        {
            if(PercHPTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                PercHPTextBox1.Text = "";
                return;
            }
            PercHPTextBox1.Text = currentPerc.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same HP remains displayed
            return;
        }

        int correctedPerc = Math.Clamp(HPperc, 0, 100);

        if(HPperc != correctedPerc) //if input wasn't in valid range, correct the textbox
        {
            PercHPTextBox1.Text = correctedPerc.ToString();
            return;
        }

        PercHPTextBox1.Text = correctedPerc.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        CurrentHPTextBox1.Text = (correctedPerc / 100 * Pokemon1.FinalStats.HP).ToString(); //call the CurrentHPTextBox textchanged event to handle the rest of the logic
    }
}