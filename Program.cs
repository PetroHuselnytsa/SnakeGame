using Microsoft.Extensions.DependencyInjection;
using SnakeGame.Controllers;

namespace SnakeGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = GameDependencyConfig.Configure();
            var snakeGameController = serviceProvider.GetRequiredService<SnakeGameController>();
            snakeGameController.LaunchTheGame();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}