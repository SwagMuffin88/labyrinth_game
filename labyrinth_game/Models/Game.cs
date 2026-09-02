using System;
using System.Threading;
using static System.Console;

namespace labyrinth_game.Models;

public class Game
{
    private World _world;
    private Player _player;

    public void Start()
    {
        Clear();
        WriteLine("Starting game...");
        Thread.Sleep(1000);

        Title = "Welcome to the maze!";

        string[,] grid = {
            { "=", "=", "=", "=", "=", "=", "=" },
            { "=", " ", "=", " ", " ", " ", "X" },
            { " ", " ", "=", " ", "=", " ", "=" },
            { "=", " ", "=", " ", "=", " ", "=" },
            { "=", " ", " ", " ", "=", " ", "=" },
            { "=", "=", "=", "=", "=", "=", "=" },
        };

        _world = new World(grid);
        _player = new Player(1, 1);

        RunGameLoop();
    }

    private void DisplayIntro()
    {
        WriteLine("Welcome to the maze!");
        WriteLine("\nInstructions");
        WriteLine("> Use the arrow keys to move");
        Write("> Try to reach the goal, which looks like this: ");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("X");
        
        ResetColor();
        WriteLine("> Press any key to start");
        ReadKey(true);
    }
    
    private void DisplayOutro()
    {
        Clear();
        WriteLine("You escaped!");
        WriteLine("Thanks for playing");
        WriteLine("Press any key to exit...");
        ReadKey(true);
    }

    private void DrawFrame()
    {
        SetCursorPosition(0, 0); // Vältimaks ekraani vilkumist Clear() asemel
        _world.Draw();
        _player.Draw();
    }

    private void HandlePlayerInput()
    {
        ConsoleKeyInfo keyInfo = ReadKey(true);
        ConsoleKey key = keyInfo.Key;

        int playerY = _player.y;
        int playerX = _player.x;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (_world.IsPositionWalkable(playerX, playerY - 1))
                    _player.y -= 1;
                break;
            case ConsoleKey.DownArrow:
                if (_world.IsPositionWalkable(playerX, playerY + 1))
                    _player.y += 1;
                break;
            case ConsoleKey.LeftArrow:
                if (_world.IsPositionWalkable(playerX - 1, playerY))
                    _player.x -= 1;
                break;
            case ConsoleKey.RightArrow:
                if (_world.IsPositionWalkable(playerX + 1, playerY))
                    _player.x += 1;
                break;
        }
    }

    private void RunGameLoop()
    {
        CursorVisible = false;
        DisplayIntro();
        Clear();

        while (true)
        {
            DrawFrame();
            HandlePlayerInput();
            
            string elementAtPlayerPosition = _world.GetElementAt(_player.x,  _player.y);
            if (elementAtPlayerPosition == "X")
            {
                break;
            }
            
            Thread.Sleep(20); // Tsükkel jätkub, break eemaldatud
        }
        
        DisplayOutro();
    }
}