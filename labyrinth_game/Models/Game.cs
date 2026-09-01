using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace labyrinth_game.Models;

public class Game
{
    public void Start()
    {
        Console.Clear();
        WriteLine("Starting game...");
        Thread.Sleep(1000);
        
        Console.Clear();

        string[,] grid = {
            { "=", "=", "=", "=", "=", "=", "=" },
            { "=", " ", "=", " ", " ", " ", "X" },
            { "O", " ", "=", " ", "=", " ", "=" },
            { "=", " ", "=", " ", "=", " ", "=" },
            { "=", " ", " ", " ", "=", " ", "=" },
            { "=", "=", "=", "=", "=", "=", "=" },
        };

        var world = new World(grid);
        world.Draw();

        var player = new Player(1, 1);
        
        WriteLine("\n Press any key to exit...");
        ReadKey(true);
    }
}