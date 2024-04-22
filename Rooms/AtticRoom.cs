using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
           
@"In the attic, it's dark and cold.
A [chest] is locked with the code.
Theres a [screwdriver] in the corner of the room.
You can return to your [bedroom].
You can check your [inventory]

";

        internal override string GameOverText()
        {
            return "You pass out in the attic, your body slowly accumilating dust and webs over the years.";
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
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "chest":
                    Console.WriteLine("Please type out the code.");
                    string number = Console.ReadLine();
                    if (number == Game.Code())
                    {
                        Console.WriteLine("You open the chest ang get the key.");
                        isKeyCollected = true;
                    }
                    else
                    {
                        Console.WriteLine("You try the code, but it doesnt seem to be right.");
                    }
                    
                  
                    break;
                case "screwdriver":
                    Console.WriteLine("You walk over and collect the screwdriver. maybe it will be useful later?");
                    GameState.HasScrewDriver = true;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
