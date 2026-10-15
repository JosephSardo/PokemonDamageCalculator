using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains code for move selection
public partial class MainWindow
{
    //Pokemon 1 functions
    
    //Move selection
    private void P1move1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(P1move1acb.SelectedItem == null)
        {
            P1move1button.Content = "Move 1";
            P1move1info.Text = "Move Info...";
        }

        if(P1move1acb.SelectedItem is Move selectedMove)
        {
            P1move1 = selectedMove;
            P1move1button.Content = P1move1.Name;
            P1move1info.Text = "BP = " + P1move1.Power + ", " + P1move1.typeAsString() + ", " + P1move1.catAsString();
        }
    }

    private void P1move2acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(P1move2acb.SelectedItem == null)
        {
            P1move2button.Content = "Move 1";
            P1move2info.Text = "Move Info...";
        }

        if(P1move2acb.SelectedItem is Move selectedMove)
        {
            P1move2 = selectedMove;
            P1move2button.Content = P1move2.Name;
            P1move2info.Text = "BP = " + P1move2.Power + ", " + P1move2.typeAsString() + ", " + P1move2.catAsString();
        }
    }

    private void P1move3acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(P1move3acb.SelectedItem == null)
        {
            P1move3button.Content = "Move 1...";
            P1move3info.Text = "Move Info";
        }

        if(P1move3acb.SelectedItem is Move selectedMove)
        {
            P1move3 = selectedMove;
            P1move3button.Content = P1move3.Name;
            P1move3info.Text = "BP = " + P1move3.Power + ", " + P1move3.typeAsString() + ", " + P1move3.catAsString();
        }
    }

    private void P1move4acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(P1move4acb.SelectedItem == null)
        {
            P1move4button.Content = "Move 1...";
            P1move4info.Text = "Move Info";
        }

        if(P1move4acb.SelectedItem is Move selectedMove)
        {
            P1move4 = selectedMove;
            P1move4button.Content = P1move4.Name;
            P1move4info.Text = "BP = " + P1move4.Power + ", " + P1move4.typeAsString() + ", " + P1move4.catAsString();
        }
    }
}