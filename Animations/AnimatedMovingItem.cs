using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class AnimatedMovingItem
    {
        private readonly Animation _animation;
        private readonly MovingItem _movingItem;

        public Vector2 Position { get => _movingItem.Position; }

        public Direction Direction
        {
            get => _movingItem.Direction;
            set
            {
                _movingItem.Direction = value;
                _animation.Direction = value;
            }
        }

        public AnimatedMovingItem(
            Animation animation,
            int speed,
            Vector2 initialPosition,
            Direction initialDirection = Direction.Down
        )
        {
            _animation = animation;
            _movingItem = new(speed, initialPosition, initialDirection);
        }

        public void Update(GameTime gameTime)
        {
            _movingItem.Update(gameTime);
            _animation.Position = _movingItem.Position;
            _animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animation.Draw(spriteBatch);
        }

        public void StartAnimation()
        {
            _animation.IsExecuting = true;
        }

        public void StopAnimation()
        {
            _animation.IsExecuting = false;
        }

        public void StartMovement()
        {
            _movingItem.StartMovement();
        }

        public void StopMovement()
        {
            _movingItem.StopMovement();
        }
    }
}
