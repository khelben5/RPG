using Microsoft.Xna.Framework;

namespace RPG
{
    class MovingItem
    {
        private readonly int _speed;
        private Vector2 _position;

        public Vector2 Position { get => _position; }

        public MovingItem(int speed, Vector2 position)
        {
            _speed = speed;
            _position = position;
        }

        public void MoveRight(float deltaTime) { _position.X += _speed * deltaTime; }
        public void MoveLeft(float deltaTime) { _position.X -= _speed * deltaTime; }
        public void MoveDown(float deltaTime) { _position.Y += _speed * deltaTime; }
        public void MoveUp(float deltaTime) { _position.Y -= _speed * deltaTime; }
    }
}
