using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class Projectile
    {
        private const int _speed = 1000;

        private readonly Texture2D _sprite;
        private readonly MovingItem _movingItem;

        public Projectile(
            Texture2D sprite,
            Direction direction,
            Vector2 initialPosition
        )
        {
            _sprite = sprite;
            _movingItem = new(_speed, initialPosition, direction);
            _movingItem.StartMovement();
        }

        public void Update(GameTime gameTime)
        {
            _movingItem.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _sprite,
                FixDrawingPosition(_movingItem.Position, _sprite),
                Color.White
            );
        }

        private Vector2 FixDrawingPosition(Vector2 position, Texture2D sprite) =>
            position - new Vector2(sprite.Bounds.Width / 2, sprite.Bounds.Height / 2);
    }
}
