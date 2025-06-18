using SnakeGame.Enums;
using SnakeGame.Levels;
using SnakeGame.Structs;


namespace SnakeGame.Entities
{
    public abstract class GameEntity
    {
        public event Action? Dead;
        protected void OnDead() => Dead?.Invoke();

        public event Action? Win;
        protected void OnWin() => Win?.Invoke();

        protected IGameEntityStateChecker? _stateChecker;

        public int CurrApplesCollected { get; protected set; }
        public int PrevApplesCollected { get; protected set; }

        protected Level? _currEntityLevel;
        public Level CurrEntityLevel
        {
            get => _currEntityLevel!;
            set
            {
                _currEntityLevel = value;
                _entityCoords = _currEntityLevel.GetSnakePosition();
            }
        }

        protected List<Point> _entityCoords;
        public IReadOnlyList<Point> EntityCoords => _entityCoords.AsReadOnly();

        protected GameEntity(Level initialLevel, IGameEntityStateChecker gameEntityStateChecker)
        {
            _entityCoords = [];
            CurrEntityLevel = initialLevel;
            _stateChecker = gameEntityStateChecker;
        }

        public abstract void Move(MoveDirection moveDirection);
        public abstract void Grow();
    }
}
