using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class Enemy
    {
        private readonly int _speed = 150;
        private readonly TargetMovement _movement;
        private readonly Animation _animation;

        public Vector2 Position => _movement.Position;
        public float Radius => _animation.Size.X / 2;

        public Enemy(
            Vector2 initialPosition,
            Vector2 initialTargetPosition,
            SpriteAnimation sprite
        )
        {
            _movement = new(_speed, initialPosition, initialTargetPosition);
            _animation = new(sprite) { IsExecuting = true };
        }

        public void Update(GameTime gameTime)
        {
            _movement.Update(gameTime);
            _animation.Position = _movement.Position;
            _animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animation.Draw(spriteBatch);
        }

        public void SetTargetPosition(Vector2 targetPosition)
        {
            _movement.SetTargetPosition(targetPosition);
        }
    }
}
