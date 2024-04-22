using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {
        internal static bool isBathLaid;
        internal override string CreateDescription() =>
@"In your bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your depressed face.
You can return to your [bedroom].
You can check your [inventory]
";
        internal override string GameOverText()
        {
            return "You pass out on the floor, your body lying halfway in the bathtub as if you were just sick from some house party.";
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
                case "bath":
                    Console.WriteLine("You relax in the bath, fog beginning to blur the mirror.");
                    isBathLaid = true;
                    break;
                case "mirror":
                    if (isBathLaid == true)
                    {
                        Console.WriteLine("You see the numbers " + Game.Code() + " written on the fog on your mirror.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The bathroom mirror shows your relfection without anything special to be seen.");
                        break;
                    }
                    
                  
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
