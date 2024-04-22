using System;
using System.Runtime.InteropServices;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class BoilerRoom : Room
    {

        internal override string CreateDescription() =>
@" The boiler room can be seen burning up due to not being turned down, causing the room to be very hot.
the [boiler] sits in the middle blowing out steam.
you can return to the [living room]
You can check your [inventory]
";
        internal override string GameOverText()
        {
            return "The heat seems to be getting the best of you with the toxins in the air as you soon are knocked out in the hot room.";
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
                case "boiler":
                    if (GameState.HasTouchedWater == true)
                    {
                        Console.WriteLine("You walk over and turn the gear, slowly turning off the pool");
                        GameState.HasWaterCold = true;
                    }
                    else
                    {
                        Console.WriteLine("You stare at the boiler, not seeing a reason to mess with it.");
                    }
                    break;
               
                case "living room":
                    Console.WriteLine("You return to your living room.");
                    Game.Transition<LivingRoom>();
                    break;
               
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
