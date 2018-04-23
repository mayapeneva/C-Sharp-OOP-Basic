using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster master;

        public Engine(DungeonMaster master)
        {
            this.master = master;
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input) && !this.master.IsGameOver())
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var args = tokens.Skip(1).ToArray();
                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(this.master.JoinParty(args));
                            break;

                        case "AddItemToPool":
                            Console.WriteLine(this.master.AddItemToPool(args));
                            break;

                        case "PickUpItem":
                            Console.WriteLine(this.master.PickUpItem(args));
                            break;

                        case "UseItem":
                            Console.WriteLine(this.master.UseItem(args));
                            break;

                        case "UseItemOn":
                            Console.WriteLine(this.master.UseItemOn(args));
                            break;

                        case "GiveCharacterItem":
                            Console.WriteLine(this.master.GiveCharacterItem(args));
                            break;

                        case "GetStats":
                            Console.WriteLine(this.master.GetStats());
                            break;

                        case "Attack":
                            Console.WriteLine(this.master.Attack(args));
                            break;

                        case "Heal":
                            Console.WriteLine(this.master.Heal(args));
                            break;

                        case "EndTurn":
                            Console.WriteLine(this.master.EndTurn(args));
                            break;
                    }
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine("Parameter Error: " + argumentException.Message);
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine("Invalid Operation: " + exception.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.master.GetStats());
        }
    }
}