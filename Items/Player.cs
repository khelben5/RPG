using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Player
    {
        private const int _speed = 300;
        private readonly Vector2 _initialPosition = new(500, 300);

        private readonly AnimatedMovingItem _movingItem;

        public Vector2 Position { get => _movingItem.Position; }
        public Direction Direction { get => _movingItem.Direction; }

        public Player(Animation animation)
        {
            _movingItem = new(animation, _speed, _initialPosition);
        }

        public void Update(GameTime gameTime)
        {
            Direction? direction = DetectDirection(Keyboard.GetState());
            if (direction == null)
            {
                _movingItem.StopAnimation();
                _movingItem.StopMovement();
            }
            else
            {
                _movingItem.Direction = (Direction)direction;
                _movingItem.StartMovement();
                _movingItem.StartAnimation();
            }

            _movingItem.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _movingItem.Draw(spriteBatch);
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
