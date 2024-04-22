using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class LivingRoom : Room
    {

        internal override string CreateDescription() =>
@"In your Living Room, the [tv] is turned off.
The [axe] is set firmly over the fireplace, bolted there by some screws.
You can return to your [bedroom].
You can exit to the [garden]
You can explore the [boiler] room.
You can check your [inventory]
";
        internal override string GameOverText()
        {
            return "You pass out in the living room, missing the couch as the tv's static plays on and on.";
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
                case "tv":
                    Console.WriteLine("You grab the remote and begin to watch family guy.");
                    break;
                case "axe":
                    Console.WriteLine("You look up at the axe and try and obtain it, but it seems you need to use something. What will you do?");
                    Console.WriteLine("[exit] and look for something to help you");
                    Console.WriteLine("Try and use a [screwdriver]");
                    string action = Console.ReadLine();
                    if (action == "exit")
                    {
                        Console.WriteLine("You back off to try again later.");
                    }
                    if (action == "screwdriver" && GameState.HasScrewDriver == true)
                    {
                        Console.WriteLine("You manage to unscrew the axe from the wall, collecting it for yourself.");
                        GameState.HasAxe = true;
                        
                    }
                    else
                    {
                        Console.WriteLine("You try to use a scredriver, but realize you don't have one.");
                    }
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "garden":
                    Console.WriteLine("You walk out into the garden");
                    Game.Transition<Garden>();
                    break;
                case "boiler":
                    Console.WriteLine("you walk to the Boiler room.");
                    Game.Transition<BoilerRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
