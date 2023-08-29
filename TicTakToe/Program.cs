using Microsoft.Extensions.DependencyInjection;
using TicTakToe;
using TicTakToe.Game;

var serviceProvider = new ServiceCollection()
    .AddTicTakToe()
    .BuildServiceProvider();
        
var game = serviceProvider.GetService<IGame>();

if (game != null)
{
    var ui = new GameUi(game, Console.In, Console.Out);
    ui.Run();
}