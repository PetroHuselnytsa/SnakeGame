using Microsoft.Extensions.DependencyInjection;
using SnakeGame.Audio;
using SnakeGame.Checkers;
using SnakeGame.Controllers;
using SnakeGame.Entities;
using SnakeGame.Entities.DefaultSnake;
using SnakeGame.Levels;
using SnakeGame.Spawners;
using SnakeGame.UI.Facades;
using SnakeGame.UI.Renderers.DefaultImplementations;
using SnakeGame.UI.Renderers.Interfaces;


namespace SnakeGame
{
    public static class GameDependencyConfig
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IGameEntityStateChecker, SnakeChecker>();
            services.AddSingleton<LevelFactory, DefaultLevelFactory>();
            services.AddSingleton<ISoundManager, WavSoundManager>();
            services.AddSingleton<IChecker, AppleChecker>();
            services.AddSingleton<ISpawner, AppleSpawner>();
            services.AddSingleton<IGameMenuRenderer, DefaultGameMenuRenderer>();
            services.AddSingleton<IGameFrameRenderer, DefaultGameFrameRenderer>();
            services.AddSingleton<IGameSettingsRenderer, DefaulGameSettingsRenderer>();
            services.AddSingleton<IGameEndScreenRenderer, DefaultGameEndScreenRenderer>();
            services.AddSingleton<IGameUI, DefaultGameUIFacade>();
            services.AddSingleton<SnakeGameController>();

            return services.BuildServiceProvider();
        }
    }
}