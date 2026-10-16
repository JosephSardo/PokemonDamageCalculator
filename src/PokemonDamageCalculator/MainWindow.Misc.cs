using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains code for misc stat selection (natures, abilities, held items, statuses)
public partial class MainWindow
{
    //Pokemon 1 Functions

    //Nature selection
    private void Nature1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1 == null)
        {
            return;
        }

        if(Nature1acb.SelectedItem is Nature selectedNature)
        {
            Pokemon1.changeNature(selectedNature);
        }
    }

    //Ability selection
    private void Ability1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1 == null)
        {
            return;
        }
        
        if(Ability1acb.SelectedItem is string selectedAbility)
        {
            Pokemon1.Ability = selectedAbility;
        }
    }

    //Item selection
    private void Item1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1 == null)
        {
            return;
        }
        
        if(Item1acb.SelectedItem is string selectedItem)
        {
            Pokemon1.Item = selectedItem;
        }
    }

    //Status selection
    private void Status1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1 == null)
        {
            return;
        }

        if(Status1acb.SelectedItem is StatusCondition selectedStatus)
        {
            Pokemon1.Status = selectedStatus;
        }
    }

    //Gender selection
    private void Gender1cb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1 == null)
        {
            return;
        }

        if(Gender1cb.SelectedItem is ComboBoxItem selectedItem)
        {
            Pokemon1.Gender = selectedItem.Content?.ToString() ?? "None";
        }
    }
}