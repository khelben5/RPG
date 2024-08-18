using Microsoft.Xna.Framework;

namespace RPG
{
    class TargetMovement
    {
        private readonly int _speed;

        private Vector2 _position;
        private Vector2 _targetPosition;

        public Vector2 Position => _position;

        public TargetMovement(
            int speed,
            Vector2 initialPosition,
            Vector2 initialTargetPosition
        )
        {
            _speed = speed;
            _position = initialPosition;
            _targetPosition = initialTargetPosition;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 direction = _targetPosition - _position;
            direction.Normalize();
            _position += direction * _speed * deltaTime;
        }

        public void SetTargetPosition(Vector2 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }
}
