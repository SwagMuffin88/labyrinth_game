namespace labyrinth_game.Models;

public class Player
{
    public int x { get; set; }
    public int y { get; set; }

    private string PlayerMarker;
    private ConsoleColor PlayerColor;
    
    public Player(int startX, int startY)
    {
        x =  startX;
        y =  startY;
        PlayerMarker = "O";
        PlayerColor = ConsoleColor.Red;
    }
}