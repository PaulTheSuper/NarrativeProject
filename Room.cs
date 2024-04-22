﻿namespace NarrativeProject
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        internal abstract string GameOverText();
        internal abstract void ReceiveChoice(string choice);
    }
}
