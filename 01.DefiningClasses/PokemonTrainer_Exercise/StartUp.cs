using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var trainers = new Dictionary<string, Trainer>();
            while (input[0] != "Tournament")
            {
                var trainerName = input[0];
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName, 0, new List<Pokemon>());
                }

                trainers[trainerName].Pokemons.Add(new Pokemon(input[1], input[2], int.Parse(input[3])));

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Value.BadgesNumber++;
                    }
                    else
                    {
                        trainer.Value.LowerPokemonsHealt();
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trn in trainers.OrderByDescending(t => t.Value.BadgesNumber))
            {
                Console.WriteLine($"{trn.Value.Name} {trn.Value.BadgesNumber} {trn.Value.Pokemons.Count}");
            }
        }
    }
}
