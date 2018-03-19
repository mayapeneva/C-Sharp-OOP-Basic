using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var trainers = new Dictionary<string, Trainer>();
        GatheringAllTrainersInfo(trainers);

        CheckPokemonsAndBadges(trainers);

        PrintResult(trainers);
    }

    private static void PrintResult(Dictionary<string, Trainer> trainers)
    {
        foreach (var trainer in trainers.Values.OrderByDescending(t => t.BadgesNumber))
        {
            Console.WriteLine($"{trainer.Name} {trainer.BadgesNumber} {trainer.Pokemons.Count}");
        }
    }

    private static void CheckPokemonsAndBadges(Dictionary<string, Trainer> trainers)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers.Values)
            {
                if (trainer.Pokemons.Any(p => p.Element.Equals(input)))
                {
                    trainer.BadgesNumber++;
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    var pokemonsToRemove = trainer.Pokemons.Where(p => p.Health <= 0);
                    trainer.Pokemons.RemoveAll(p => pokemonsToRemove.Contains(p));
                }
            }
        }
    }

    private static void GatheringAllTrainersInfo(Dictionary<string, Trainer> trainers)
    {
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trainerName = args[0];
            var pokemonName = args[1];
            var element = args[2];
            var health = int.Parse(args[3]);

            var pokemon = new Pokemon(pokemonName, element, health);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers[trainerName] = new Trainer(trainerName);
            }

            trainers[trainerName].Pokemons.Add(pokemon);
        }
    }
}