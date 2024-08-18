using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class Enemy
    {
        private readonly int _speed = 150;
        private readonly AnimatedMovingItem _animatedItem;

        public Enemy(
            Vector2 initialPosition,
            Direction direction,
            SpriteAnimation animation
        )
        {
            _animatedItem = new(
                animation: new(animation),
                _speed,
                initialPosition,
                direction
            );
            // _animatedItem.StartAnimation();
            _animatedItem.StartMovement();
        }

        public void Update(GameTime gameTime)
        {
            _animatedItem.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animatedItem.Draw(spriteBatch);
        }
    }
}
