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

        while (true)
        {
            DrawFrame();
            HandlePlayerInput();
            Thread.Sleep(20); // Tsükkel jätkub, break eemaldatud
        }
    }
}