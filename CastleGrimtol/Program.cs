using System;
using GrimtolLibrary;

namespace CastleGrimtol
{
    class Program
    {
        // Prereqs: needs business layer (class library) and presentation layer (this console app)
        // Business layer exposes 3 methods: StartGame(), ProcessCommand(), GetGameState(string gameId)
        // Class library must be protected outside of the exposed methods
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
            var api = new GrimtolApi();
            
            Console.WriteLine("Welcome to Castle Grimtol. What is your name adventurer?");
            var playerName = Console.ReadLine();
            Console.WriteLine($"Welcome honorable {playerName}. Your adventure begins now!");
            Console.WriteLine();
            api.StartGame();

        }
    }
}