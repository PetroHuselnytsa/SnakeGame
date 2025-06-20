using SnakeGame.Checkers;
using SnakeGame.Entities.DefaultSnake;
using SnakeGame.Entities;
using SnakeGame.Enums;
using SnakeGame.Levels;
using SnakeGame.Spawners;
using SnakeGame.UI.Facades;
using SnakeGame.UI.Renderers.Records;
using SnakeGame.Structs;

namespace SnakeGame.Controllers
{
    public class SnakeGameController
    {
        private MoveDirection _moveDirection;
        private int _currLevelNumber;
        private int _currApplesToWin;

        private Level _currentLevel;
        private readonly LevelFactory _levelGenerator;

        private readonly ISpawner _spawner;
        private readonly IChecker _checker;

        private readonly GameEntity _entity;
        private readonly IGameUI _gameUI;

        private CancellationTokenSource _cts = new();
        public SnakeGameController(LevelFactory levelGenerator, IGameUI gameUI, ISpawner spawner, IChecker checker, IGameEntityStateChecker entityStateChecker)
        {
            _moveDirection = MoveDirection.Up;
            _currLevelNumber = 1;
            _currApplesToWin = 5;

            _levelGenerator = levelGenerator;
            _currentLevel = levelGenerator.GenerateNewLevel(_currApplesToWin, _currLevelNumber);

            _spawner = spawner;
            _checker = checker;
            _gameUI = gameUI;

            _entity = new Snake(_currentLevel, entityStateChecker);

            _entity.Dead += StopGameDrawing;
            _entity.Dead += LoseSreenWrapper;
            _entity.Dead += LaunchTheGame;

            _entity.Win += StopGameDrawing;
            _entity.Win += WinSreenWrapper;
            _entity.Win += UpdateTheLevel;
            _entity.Win += LaunchTheGame;
        }

        private void Play()
        {
            _cts = new CancellationTokenSource();
            CancellationToken cancellationToken = _cts.Token;

            Thread.Sleep(25);
            Task.Run(() => LaunchLevel(cancellationToken), cancellationToken);
            Task.Run(() => ReadUserInput(cancellationToken), cancellationToken);
        }
        private void LoseSreenWrapper()
        {
            GameRenderData gameRenderData = new(
                default!,
                default!,
                _entity.CurrApplesCollected,
                _entity.CurrEntityLevel.ApplesToWin,
               default!
            );
            _gameUI.ShowLoseScreen(gameRenderData);
        }
        private void WinSreenWrapper()
        {
            GameRenderData gameRenderData = new(
                default!,
                default!,
                _entity.CurrApplesCollected,
                _entity.CurrEntityLevel.ApplesToWin,
                _entity.CurrEntityLevel.LevelNumber
            );
            _gameUI.ShowWinScreen(gameRenderData);
        }
        private void UpdateTheLevel()
        {
            _currLevelNumber++;
            _currApplesToWin += 5;
            _currentLevel = _levelGenerator.GenerateNewLevel(_currApplesToWin, _currLevelNumber);
            _entity.CurrEntityLevel = _currentLevel;
        }
        private void StopGameDrawing()
        {
            _cts.Cancel();
            _moveDirection = MoveDirection.Up;
        }
        private void LaunchLevel(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                GameRenderData currRenderData = new(
                    _entity.CurrEntityLevel.Map,
                    _entity.EntityCoords,
                    _entity.CurrApplesCollected,
                    _entity.CurrEntityLevel.ApplesToWin,
                    _entity.CurrEntityLevel.LevelNumber
                );
                _gameUI.DrawFrame(currRenderData, this);
                Thread.Sleep(10);
                _entity.Move(_moveDirection);
            }
        }
        private void ReadUserInput(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(intercept: true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.W:
                        _moveDirection = MoveDirection.Up;
                        break;
                    case ConsoleKey.S:
                        _moveDirection = MoveDirection.Down;
                        break;
                    case ConsoleKey.A:
                        _moveDirection = MoveDirection.Left;
                        break;
                    case ConsoleKey.D:
                        _moveDirection = MoveDirection.Right;
                        break;
                }
                Thread.Sleep(10);
            }
        }

        public void LaunchTheGame()
        {
            var gameState = _gameUI.ShowMenu();
            switch (gameState)
            {
                case GameState.Play:
                    Play();
                    break;
                case GameState.Settings:
                    _gameUI.ShowSettings();
                    LaunchTheGame();
                    break;
                case GameState.Exit:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case GameState.None:
                    break;
            }
        }
        public Point TrySpawnApple()
        {
            bool isEated = _checker.CheckIsCollectedItem(_spawner.SpawnedItemPosition, _entity);
            if (isEated) _entity.Grow();
            return _spawner.Spawn(_entity.CurrEntityLevel, _entity);
        }
    }
}
