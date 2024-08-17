using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Player
    {
        private const int _speed = 300;
        private readonly Vector2 _initialPosition = new(500, 300);

        private readonly AnimatedItem _animatedItem;

        public Vector2 Position { get => _animatedItem.Position; }
        public Vector2 Size { get => _animatedItem.Size; }
        public Direction Direction { get => _animatedItem.Direction; }

        public Player(MovingAnimation animation)
        {
            _animatedItem = new(
                animation: animation,
                movingItem: new(_speed, _initialPosition)
            );
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (IsKeyDown(Keys.Right)) _animatedItem.MoveRight(deltaTime);
            else if (IsKeyDown(Keys.Left)) _animatedItem.MoveLeft(deltaTime);
            else if (IsKeyDown(Keys.Down)) _animatedItem.MoveDown(deltaTime);
            else if (IsKeyDown(Keys.Up)) _animatedItem.MoveUp(deltaTime);
            else _animatedItem.Stop();

            _animatedItem.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animatedItem.Draw(spriteBatch);
        }

        private bool IsKeyDown(Keys key) => Keyboard.GetState().IsKeyDown(key);
    }
}
