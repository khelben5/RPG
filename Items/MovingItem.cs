using Microsoft.Xna.Framework;

namespace RPG
{
    class MovingItem
    {
        private readonly int _speed;

        private Vector2 _position;
        private bool _isMoving = false;

        public Vector2 Position { get => _position; }
        public Direction Direction;

        public MovingItem(
            int speed,
            Vector2 position,
            Direction initialDirection = Direction.Down
        )
        {
            _speed = speed;
            _position = position;
            Direction = initialDirection;
        }

        public void Update(GameTime gameTime)
        {
            if (!_isMoving) return;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (Direction)
            {
                case Direction.Down:
                    MoveDown(deltaTime);
                    break;
                case Direction.Up:
                    MoveUp(deltaTime);
                    break;
                case Direction.Right:
                    MoveRight(deltaTime);
                    break;
                case Direction.Left:
                    MoveLeft(deltaTime);
                    break;
            }
        }

        public void StartMovement()
        {
            _isMoving = true;
        }

        public void StopMovement()
        {
            _isMoving = false;
        }

        private void MoveRight(float deltaTime) { _position.X += _speed * deltaTime; }
        private void MoveLeft(float deltaTime) { _position.X -= _speed * deltaTime; }
        private void MoveDown(float deltaTime) { _position.Y += _speed * deltaTime; }
        private void MoveUp(float deltaTime) { _position.Y -= _speed * deltaTime; }
    }
}
