using Microsoft.Xna.Framework;

namespace RPG
{
    class DirectionMovement
    {
        private readonly int _speed;
        private Vector2 _position;
        private Rectangle? _boundaries;

        public Vector2 Position => _position;
        public Direction Direction { get; set; }

        public DirectionMovement(
            int speed,
            Vector2 initialPosition,
            Direction initialDirection = Direction.Down,
            Rectangle? boundaries = null
        )
        {
            _speed = speed;
            _position = initialPosition;
            _boundaries = boundaries;
            Direction = initialDirection;
        }

        public void Update(GameTime gameTime)
        {
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

        private void MoveRight(float deltaTime)
        {
            UpdatePositionIfInsideBoundaries(new(_position.X + _speed * deltaTime, _position.Y));
        }

        private void MoveLeft(float deltaTime)
        {
            UpdatePositionIfInsideBoundaries(new(_position.X - _speed * deltaTime, _position.Y));
        }

        private void MoveDown(float deltaTime)
        {
            UpdatePositionIfInsideBoundaries(new(_position.X, _position.Y + _speed * deltaTime));
        }

        private void MoveUp(float deltaTime)
        {
            UpdatePositionIfInsideBoundaries(new(_position.X, _position.Y - _speed * deltaTime));
        }

        private void UpdatePositionIfInsideBoundaries(Vector2 newPosition)
        {
            bool isInsideBoundaries = _boundaries?.Contains(newPosition) ?? true;
            if (isInsideBoundaries) _position = newPosition;
        }
    }
}
