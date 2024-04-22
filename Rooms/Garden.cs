using System;
using System.Diagnostics.Eventing.Reader;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
  
    internal class Garden : Room
    {
        internal static bool isvinescut;
        internal override string CreateDescription() =>
@"The garden is lush with flowers, a [watering can] leaning against the well as well as a dangeous 
[plant] eating a pair of pants. Flowers are blooming 
everywhere and a door to the [pool] room was overgrown with vines.
you can return to the [living room]
You can check your [inventory]
";
        internal override string GameOverText()
        {
            return "You pass out in the Garden, vines and wildlife slowly overtaking your body as the time goes by.";
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
                case "watering can":
                    Console.WriteLine("You walk over and pick up the watering can. It seems to be empty.");
                    GameState.HasWateringCan = true;
                    break;
                case "living room":
                    Console.WriteLine("You walk back to your living room.");
                    Game.Transition<LivingRoom>();
                    break;
                case "plant":
                    Console.WriteLine("The plant stares at you and growls. What do you do?");
                    Console.WriteLine("feed it [water]");
                    Console.WriteLine("[back] away");
                    string choose = Console.ReadLine();
                    if (choose == "water" && GameState.HasWater == true)
                    {
                        Console.WriteLine("You water the plant, making it seemingly happy as it opens its mouth, revealing a sword inside. you take it and keep it with you.");
                        GameState.HasStabby = true;
                    }
                    else
                    {
                        Console.WriteLine("You try to water the plant, but you have no water to do so, causing it to snap at you, nearly missing you.");
                    }
                    if (choose == "back")
                    {
                        Console.WriteLine("You decide to keep your distance and look somewhere else.");
                    }
                    break;
                case "pool":
                    if (GameState.HasAxe == true)
                    {
                        Console.WriteLine("You break through the vines with your axe, gaining access to the pool.");
                        Game.Transition<Pool>();
                    }
                    else
                    {
                        Console.WriteLine("You try and enter the pool, but the vines refuse to let you pass.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
