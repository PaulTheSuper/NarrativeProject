using System;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You are in your bedroom.
The [door] in front of you leads to the exit.
Your private [bathroom] is to your left.
From your closet, you see the [attic].
You also see the hallway to the [living room]
you can check your [inventory]
";
        internal override string GameOverText()
        {
            return "As you walk into the room, you feel drowsy and go to lie on the bed for a bit. You never get up from that rest.";
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
                case "bathroom":
                    if (GameState.HasBathKey == true)
                    {
                        Console.WriteLine("You unlock the bathroom and walk in.");
                        Game.Transition<Bathroom>();
                    }
                    else
                    {
                        Console.WriteLine("You try and enter the bathroom, but its locked.");
                    }
                    
                    
                    break;
                case "door":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Game.Transition<FightRoom>();
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
                    break;
                case "living room":
                    Console.WriteLine("You walk to the living room");
                    Game.Transition<LivingRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
