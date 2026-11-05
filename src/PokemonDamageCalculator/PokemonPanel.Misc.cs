using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator.Views;

//This mainwindow file contains code for misc stat selection (natures, abilities, held items, statuses)
public partial class PokemonPanel : UserControl
{
    //Pokemon 1 Functions

    //Nature selection
    private void NatureAcb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon == null)
        {
            return;
        }

        if(NatureAcb.SelectedItem is Nature selectedNature)
        {
            Pokemon.changeNature(selectedNature);
        }
    }

    //Ability selection
    private void AbilityAcb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon == null)
        {
            return;
        }
        
        if(AbilityAcb.SelectedItem is string selectedAbility)
        {
            Pokemon.Ability = selectedAbility;
        }
    }

    //Item selection
    private void ItemAcb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon == null)
        {
            return;
        }
        
        if(ItemAcb.SelectedItem is string selectedItem)
        {
            Pokemon.Item = selectedItem;
        }
    }

    //Status selection
    private void StatusCb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon == null)
        {
            return;
        }

        if(StatusCb.SelectedItem is ComboBoxItem selectedItem)
        {
            StatusCondition selectedStatus;
            string? item = selectedItem.Content?.ToString()!; //convert selected item into a string

            //determine which status was selected (the list is short so we use brute force)
            if(item == "Healthy")
            {
                selectedStatus = StatusCondition.Healthy;
            }else if(item == "Burned")
            {
                selectedStatus = StatusCondition.Burned;
            }else if(item == "Paralyzed")
            {
                selectedStatus = StatusCondition.Paralyzed;
            }else if(item == "Poisoned")
            {
                selectedStatus = StatusCondition.Poisoned;
            }else if(item == "Badly Poisoned")
            {
                selectedStatus = StatusCondition.BadlyPoisoned;
            }else if(item == "Asleep")
            {
                selectedStatus = StatusCondition.Asleep;
            }else if(item == "Frozen")
            {
                selectedStatus = StatusCondition.Frozen;
            }
            else
            {
                return;
            }

            Pokemon.Status = selectedStatus;
        }
    }

    //Gender selection
    private void GenderCb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon == null)
        {
            return;
        }

        if(GenderCb.SelectedItem is ComboBoxItem selectedItem)
        {
            Pokemon.Gender = selectedItem.Content?.ToString() ?? "None";
        }
    }

    //Nature selection lost focus handler
    private void NatureAcb_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;

        if (string.IsNullOrWhiteSpace(NatureAcb.Text))
        {
            NatureAcb.Text = Pokemon.Nature.ToString();
        }
    }

    //Ability selection lost focus handler
    private void AbilityAcb_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;

        if (string.IsNullOrWhiteSpace(AbilityAcb.Text))
        {
            AbilityAcb.Text = Pokemon.Ability;
        }
    }

    //Held item selection lost focus handler
    private void ItemAcb_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;

        if (string.IsNullOrWhiteSpace(ItemAcb.Text))
        {
            ItemAcb.Text = Pokemon.Item;
        }
    }
}