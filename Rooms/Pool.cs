using System;
using System.Diagnostics.Eventing.Reader;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
  
    internal class Pool : Room
    {
        internal static bool isvinescut;
        internal override string CreateDescription() =>
@"The pool was full of warm [water], 
A diving board could be seen in the distance, as well as something at the [bottom] of the pool...
you can also return to the [garden]
You can check your [inventory]
";
        internal override string GameOverText()
        {
            return "You pass out in the pool, your body floating in the water until it eventually sinks.";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "inventory":
                    if (GameState.HasScrewDriver == true)
                    {
                        Console.WriteLine("You have a screwdriver");
                    }
                    if (GameState.HasAxe == true)
                    {
                        Console.WriteLine("You have an axe");
                    }
                    if (GameState.HasWateringCan == true)
                    {
                        Console.WriteLine("You have a Watering can");
                    }
                    if (GameState.HasBathKey == true)
                    {
                        Console.WriteLine("You have the bathroom key");
                    }
                    if (GameState.HasStabby == true)
                    {
                        Console.WriteLine("You have a sword");
                    }
                    break;
                case "water":
                    if (GameState.HasWateringCan == false && GameState.HasTouchedWater == false)
                    {
                        Console.WriteLine("You reach down and touch the water, burning your hand as you touch it. its too hot to go inside.");
                        GameState.HasTouchedWater = true;
                    }
                    else if (GameState.HasWateringCan == true && GameState.HasTouchedWater == false)
                    {
                        Console.WriteLine("You try and scoop up the water with your watering can, but the water heats it up quickly, making you pour it back out.");
                        GameState.HasTouchedWater = true;
                    }
                    else if (GameState.HasWateringCan == true && GameState.HasTouchedWater == true)
                    {
                        Console.WriteLine("You collect the water in your watering can. Maybe you could use it somewhere...");
                        GameState.HasWater = true;  
                    }
                    
                    break;
               
                case "bottom":
                   if (GameState.HasWaterCold == true)
                    {
                        Console.WriteLine("You dive to the bottom of the water to collect what seems to be a key.");
                        GameState.HasBathKey = true;
                    }
                    else
                    {
                        Console.WriteLine("The waters too hot. you would get burnt if you tried to swim in there.");
                    }
                    break;
                case "garden":
                    Console.WriteLine("You turn around and head back to the garden.");
                    Game.Transition<Garden>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
