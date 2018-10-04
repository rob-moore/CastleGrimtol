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
            
            Console.WriteLine(@"    ,----..                            ___     ,--,                       ,----..                               ____      ___               ,--,    
   /   /   \                         ,--.'|_ ,--.'|                      /   /   \             ,--,           ,'  , `.  ,--.'|_           ,--.'|    
  |   :     :                        |  | :,'|  | :                     |   :     :   __  ,-.,--.'|        ,-+-,.' _ |  |  | :,'   ,---.  |  | :    
  .   |  ;. /              .--.--.   :  : ' ::  : '                     .   |  ;. / ,' ,'/ /||  |,      ,-+-. ;   , ||  :  : ' :  '   ,'\ :  : '    
  .   ; /--`   ,--.--.    /  /    '.;__,'  / |  ' |      ,---.          .   ; /--`  '  | |' |`--'_     ,--.'|'   |  ||.;__,'  /  /   /   ||  ' |    
  ;   | ;     /       \  |  :  /`./|  |   |  '  | |     /     \         ;   | ;  __ |  |   ,',' ,'|   |   |  ,', |  |,|  |   |  .   ; ,. :'  | |    
  |   : |    .--.  .-. | |  :  ;_  :__,'| :  |  | :    /    /  |        |   : |.' .''  :  /  '  | |   |   | /  | |--' :__,'| :  '   | |: :|  | :    
  .   | '___  \__\/: . .  \  \    `. '  : |__'  : |__ .    ' / |        .   | '_.' :|  | '   |  | :   |   : |  | ,      '  : |__'   | .; :'  : |__  
  '   ; : .'| ,' .--.; |   `----.   \|  | '.'|  | '.'|'   ;   /|        '   ; : \  |;  : |   '  : |__ |   : |  |/       |  | '.'|   :    ||  | '.'| 
  '   | '/  :/  /  ,.  |  /  /`--'  /;  :    ;  :    ;'   |  / |        '   | '/  .'|  , ;   |  | '.'||   | |`-'        ;  :    ;\   \  / ;  :    ; 
  |   :    /;  :   .'   \'--'.     / |  ,   /|  ,   / |   :    |        |   :    /   ---'    ;  :    ;|   ;/            |  ,   /  `----'  |  ,   /  
   \   \ .' |  ,     .-./  `--'---'   ---`-'  ---`-'   \   \  /          \   \ .'            |  ,   / '---'              ---`-'            ---`-'   
    `---`    `--`---'                                   `----'            `---`               ---`-'                                                
                                                                                                                                                    ");
            Console.WriteLine("Welcome to Castle Grimtol. What is your name adventurer?");
            var playerName = Console.ReadLine();
            Console.WriteLine($"Welcome honorable {playerName}. Your adventure begins now!");
            Console.WriteLine();
            api.StartGame();
            
            while (api.GetGameState().Equals(1))
            { 
                Console.WriteLine(api.ProcessCommand(Console.ReadLine()));
            }
            
        }
    }
}