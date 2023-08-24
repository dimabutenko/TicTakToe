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

            int fieldSize;
            do
            {
                _output.WriteLine("Enter size:");
            } while (!int.TryParse(_input.ReadLine(), out fieldSize));

            var game = new Game.Game(fieldSize);

            for (var i = 1; i < fieldSize * fieldSize; i++)
            {
                var player = i % 2 == 0;
                _output.WriteLine($"Player {(player ? "X" : "O") } move:");
                var point = GetMoveData();
                var result = game.MakeMove(point.X, point.Y, player);
                PrintGameField(game.GetField());

                if (result == GameResult.IncorrectMove)
                {
                    i--;
                }
                else if (result is GameResult.WinnerCrosses or GameResult.WinnerZeros or GameResult.Draw)
                {
                    _output.WriteLine(result);
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