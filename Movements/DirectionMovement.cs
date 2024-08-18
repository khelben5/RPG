using Microsoft.Xna.Framework;

namespace RPG
{
    class DirectionMovement
    {
        private readonly int _speed;
        private Vector2 _position;

        public Vector2 Position => _position;
        public Direction Direction { get; set; }

        public DirectionMovement(
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

        private void MoveRight(float deltaTime) { _position.X += _speed * deltaTime; }
        private void MoveLeft(float deltaTime) { _position.X -= _speed * deltaTime; }
        private void MoveDown(float deltaTime) { _position.Y += _speed * deltaTime; }
        private void MoveUp(float deltaTime) { _position.Y -= _speed * deltaTime; }
    }
}
