using NarrativeProject.Rooms;
using System;
using static NarrativeProject.Room;

namespace NarrativeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var game = new Game();
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new AtticRoom());
            game.Add(new LivingRoom());
            game.Add(new Garden());
            game.Add(new Pool());
            game.Add(new BoilerRoom());
            game.Add(new FightRoom());
            Game.GenerateCode();

            while (!game.IsGameOver() && Game.HP > 0)
            {
                Console.WriteLine(Game.HP);
                Console.WriteLine("--");
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
            }
          
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
