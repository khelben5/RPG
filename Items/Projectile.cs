using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class Projectile
    {
        private const int _speed = 1000;

        private readonly Texture2D _sprite;
        private readonly MovingItem _movingItem;
        private readonly Direction _direction;
        private readonly Vector2 _drawOffset;

        public Projectile(
            Texture2D sprite,
            Direction direction,
            Vector2 position,
            Vector2 drawOffset
        )
        {
            _sprite = sprite;
            _direction = direction;
            _movingItem = new(_speed, position);
            _drawOffset = drawOffset;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (_direction)
            {
                case Direction.Down:
                    _movingItem.MoveDown(deltaTime);
                    break;
                case Direction.Up:
                    _movingItem.MoveUp(deltaTime);
                    break;
                case Direction.Right:
                    _movingItem.MoveRight(deltaTime);
                    break;
                case Direction.Left:
                    _movingItem.MoveLeft(deltaTime);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _sprite,
                _movingItem.Position - _drawOffset,
                Color.White
            );
        }
    }
}
