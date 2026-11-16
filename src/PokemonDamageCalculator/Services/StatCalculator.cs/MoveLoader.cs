using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PokemonDamageCalculator.Models;

namespace PokemonDamageCalculator.Services;

public static class MoveLoader
{
    public static Dictionary<string, Move> LoadMoves(string filepath)
    {
        //turn json into readable string
        string json = File.ReadAllText(filepath);

        //tell library to ignore case when deserializing
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //deserialize the json. the string is the id of the move, eg "absorb", and the MoveDto stores all data about the move
        Dictionary<string, MoveDto>? moveData = JsonSerializer.Deserialize<Dictionary<string, MoveDto>>(json, options);
        if(moveData == null)
        {
            throw new InvalidDataException("Failed to deserialize moves.json in MoveLoader.cs");
        }

        //dictionary mapping a move id to its move object
        Dictionary<string, Move> moveList = new();
        foreach(var (id, dto) in moveData)
        {
            //get move name
            string name = dto.Name;

            //get move type
            if(!Enum.TryParse<PokemonType>(dto.Type, ignoreCase: true, out var type))
            {
                Console.WriteLine("Failed to parse type of move " + name + ". This move won't be added to the dictionary. ");
                continue;
            }

            //get category
            if(!Enum.TryParse<MoveCategory>(dto.Category, ignoreCase: true, out var category))
            {
                Console.WriteLine("Failed to parse category of move " + name + ". This move won't be added to the dictionary. ");
                continue;
            }

            //get base power (0 if move is status)
            int bp = dto.BasePower ?? 0;

            //get accuracy (101 if move is guaranteed hit)
            int acc = dto.Accuracy ?? 101;

            //construct move
            Move move = new(name, bp, acc, type, category);
            moveList.Add(id, move);
        }

        return moveList;
    }
}