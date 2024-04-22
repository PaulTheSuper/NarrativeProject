using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NarrativeProject
{
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        static int code;
        static public int HP = 50;
        
        public class GameState
        {
            public static bool HasTouchedWater { get; set; }
            public static bool HasScrewDriver { get; set; }
            public static bool HasAxe { get; set; }
            public static bool HasWateringCan {  get; set; }
            public static bool HasWaterCold { get; set; }
            public static bool HasBathKey { get; set; }
            public static int Code { get; set; }
            public static int Potions { get; set; }
            public static bool HasWater {  get; set; }
            public static bool HasStabby { get; set; }
        }

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            HP--;
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }
        static public void GenerateCode()
        {
            Random random = new Random();
            code = random.Next(1000,1000000000);
        }
        static public string Code()
        {
            return code.ToString();
        }
        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
    }
}
