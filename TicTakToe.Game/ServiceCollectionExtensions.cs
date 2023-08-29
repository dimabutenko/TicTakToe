using Microsoft.Extensions.DependencyInjection;

namespace TicTakToe.Game;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTicTakToe(this IServiceCollection services)
    {
        services.AddSingleton<IGame, Game>();
        services.AddSingleton<IGameService, GameService>();

        return services;
    }
}