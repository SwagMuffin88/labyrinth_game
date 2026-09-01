using System;
using static System.Console;

namespace labyrinth_game.Models;

public class World
{
    private string[,] Grid;
    private int Rows;
    private int Cols;

    public World(string[,] grid)
    {
        Grid = grid;
        Rows = grid.GetLength(0);
        Cols = grid.GetLength(1);
    }

    public void Draw()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                string element = Grid[y, x];
                SetCursorPosition(x, y);
                Write(element);
            }
        }
    }
}