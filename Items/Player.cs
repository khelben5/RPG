using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Player
    {
        private const int _speed = 300;

        private readonly Vector2 _initialPosition = new(500, 300);
        private readonly Animation _animation;
        private readonly DirectionMovement _movement;
        private bool _isMoving;

        public Vector2 Position => _movement.Position;
        public Direction Direction => _movement.Direction;

        public Player(Animation animation)
        {
            _animation = animation;
            _animation.Position = _initialPosition;
            _movement = new(_speed, _initialPosition);
            _isMoving = false;
        }

        public void Update(GameTime gameTime)
        {
            Direction? direction = DetectDirection(Keyboard.GetState());
            if (direction == null)
            {
                _isMoving = false;
                _animation.IsExecuting = false;
            }
            else
            {
                _movement.Direction = (Direction)direction;
                _animation.Direction = (Direction)direction;
                _isMoving = true;
                _animation.IsExecuting = true;
            }

            if (!_isMoving) return;

            _movement.Update(gameTime);
            _animation.Position = _movement.Position;
            _animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animation.Draw(spriteBatch);
        }

        private Direction? DetectDirection(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right)) return Direction.Right;
            if (keyboardState.IsKeyDown(Keys.Left)) return Direction.Left;
            if (keyboardState.IsKeyDown(Keys.Down)) return Direction.Down;
            if (keyboardState.IsKeyDown(Keys.Up)) return Direction.Up;
            return null;
        }
    }
}
