using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PokemonDamageCalculator.Models;
using System.Linq;

namespace PokemonDamageCalculator.Services;

public static class PokemonLoader
{
    public static List<Pokemon> LoadPokemon(string filepath)
    {
        //turn json into readable string
        string json = File.ReadAllText(filepath);

        //tell library to ignore case when deserializing
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //deserialize the json. the string is the id of the pokemon, eg "bulbasaur," and the PokemonDto stores all info about the pokemon
        Dictionary<string, PokemonDto>? pokemonData = JsonSerializer.Deserialize<Dictionary<string, PokemonDto>>(json, options);
        if(pokemonData == null)
        {
            throw new InvalidDataException("Failed to deserialize pokemon.json in PokemonLoader.cs");
        }

        //fill out a list of pokemon objects
        List<Pokemon> pokemonList = new List<Pokemon>();
        foreach(PokemonDto dto in pokemonData.Values)
        {
            //skip cosmetic types and MissingNo
            if (dto.IsCosmeticForme || dto.Name == "MissingNo.")
            {
                continue;
            }

            //obtain type 1
            if(dto.Types.Count < 1 || !Enum.TryParse<PokemonType>(dto.Types[0], ignoreCase: true, out var type1))
            {
                Console.WriteLine("Failed to parse first type of pokemon " + dto.Name + ". This pokemon won't be added to the list. ");
                continue;
            }

            //obtain type 2
            PokemonType? type2;
            if(dto.Types.Count < 2)
            {
                type2 = null;
            }
            else if(!Enum.TryParse<PokemonType>(dto.Types[1], ignoreCase: true, out var Type2))
            {
                Console.WriteLine("Failed to parse second type of pokemon " + dto.Name + ". This pokemon won't be added to the list. ");
                continue;
            }
            else
            {
                type2 = Type2;
            }

            //obtain base stats
            Stats baseStats = new(dto.BaseStats.HP, dto.BaseStats.Atk, dto.BaseStats.Def, dto.BaseStats.SpAtk, dto.BaseStats.SpDef, dto.BaseStats.Speed);

            //construct pokemon object, add it to the list
            Pokemon pokemon = new(dto.Name, baseStats, type1, type2);
            pokemonList.Add(pokemon);
        }

        Console.WriteLine($"Loaded {pokemonList.Count} Pokemon.");

        foreach (var pokemon in pokemonList.Take(5))
        {
            Console.WriteLine(
                $"{pokemon.Name}: {pokemon.Types.Type1}, {pokemon.BaseStats.HP} HP"
            );
        }

        return pokemonList;
    }
}