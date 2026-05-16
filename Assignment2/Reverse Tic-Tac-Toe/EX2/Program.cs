using EX2;


public class Program
{
    public static void Main(string[] args)
    {

        Game game = new Game();
        game.Start();
        game.ChooseOpponent();
        game.GamePlay();

    }
}