using System.Drawing;
using TicTakToe.Game;

namespace TicTakToe;

public class GameUi
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public GameUi(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    public void Run()
    {
        while (true)
        {
            if (GetOption() == 0)
            {
                break;
            }
            
            var game = new Game.Game();

            for (var i = 1; i < 9; i++)
            {
                var player = i % 2 == 0;
                _output.WriteLine($"Player {(player ? "X" : "O") } move:");
                var point = GetMoveData();
                var result = game.MakeMove(point.X, point.Y, player);
                PrintGameField(game.Field);

                if (result == Result.IncorrectMove)
                {
                    i--;
                }
                else if (result is Result.WinnerCrosses or Result.WinnerZeros or Result.Draw)
                {
                    _output.WriteLine(result);
                    _output.WriteLine("#####################");
                    break;
                }
            }
        }
    }

    private int GetOption()
    {
        int x;
        do
        {
            _output.WriteLine("New Game: 1");
            _output.WriteLine("Exit: 0");
        } while (!int.TryParse(_input.ReadLine(), out x));

        return x;
    }

    private Point GetMoveData()
    {
        int x;
        do
        {
            _output.Write("Enter X:");
        } while (!int.TryParse(_input.ReadLine(), out x));
        
        int y;
        do
        {
            _output.Write("Enter Y:");
        } while (!int.TryParse(_input.ReadLine(), out  y));
    
        return new Point(x, y);
    }
    
    private void PrintGameField(bool?[,]? field)
    {
        if (field != null)
        {
            for (var i = 0; i < field.GetLength(0); i++)
            {
                for (var j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == null)
                    {
                        _output.Write("_ ");
                    }
                    else
                    {
                        _output.Write((field[i, j] == true ? "X" : "O") + " ");
                    }
                }

                _output.WriteLine();
            }
            
            _output.WriteLine("*********************");
        }
    }
}