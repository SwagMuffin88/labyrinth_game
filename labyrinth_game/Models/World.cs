namespace labyrinth_game.Models;
using System;
using static System.Console;

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

    public bool IsPositionWalkable(int x, int y)
    {
        if (x < 0 || x >= Cols || y < 0 || y >= Rows)
        {
            return false;
        }
        
        return Grid[y, x] == " " || Grid[y, x] == "X";
    }
}