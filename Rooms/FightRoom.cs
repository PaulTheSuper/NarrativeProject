using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using static NarrativeProject.Game;

namespace NarrativeProject.Rooms
{

    internal class FightRoom : Room
    {
        internal static bool isvinescut;
        internal override string CreateDescription() =>
@"You Enter the mysterious room as you see a creature looming in the darkness... what do you do?
Choose to [fight] the monster even though you are unarmed.
[return] and explore some more.
";
        internal override string GameOverText()
        {
            return "You pass out in the strange room, the monster that lives there now has a feast.";
        }

        internal override void ReceiveChoice(string Choose)
        {
            switch (Choose)
            {
                case "return":
                    Console.WriteLine("You back off from the monster, deciding to look around some more.");
                    Game.Transition<LivingRoom>();
                    break;
                case "fight":
                    Random chance = new Random();
                    int choice = chance .Next(0, 100);
                    if (GameState.HasStabby != true)
                    {

                        if (choice < 100)
                        {
                            Console.WriteLine("With the odds against you, you manage to slay the monster bare handed! YOU WIN");
                            Game.Finish();
                        }
                        else
                        {
                            Console.WriteLine("You try to beat the monster bare handed, but you fail and are defeated. GAME OVER");
                            Game.Finish();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Using your sword, you manage to defeat the monster, able to leave victorious. YOU WIN");
                        Game.Finish();
                    }



                    break;



                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
        
    

