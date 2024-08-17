using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class AnimatedItem
    {
        private readonly MovingAnimation _animation;
        private readonly MovingItem _movingItem;

        public Vector2 Position { get => _movingItem.Position; }
        public Vector2 Size { get => _animation.Size; }
        public Direction Direction { get => _animation.Direction; }

        public AnimatedItem(MovingAnimation animation, MovingItem movingItem)
        {
            _animation = animation;
            _movingItem = movingItem;
        }

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime, _movingItem.Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animation.Draw(spriteBatch);
        }

        public void MoveRight(float deltaTime)
        {
            _movingItem.MoveRight(deltaTime);
            _animation.Direction = Direction.Right;
            _animation.IsRunning = true;
        }

        public void MoveLeft(float deltaTime)
        {
            _movingItem.MoveLeft(deltaTime);
            _animation.Direction = Direction.Left;
            _animation.IsRunning = true;
        }

        public void MoveDown(float deltaTime)
        {
            _movingItem.MoveDown(deltaTime);
            _animation.Direction = Direction.Down;
            _animation.IsRunning = true;
        }

        public void MoveUp(float deltaTime)
        {
            _movingItem.MoveUp(deltaTime);
            _animation.Direction = Direction.Up;
            _animation.IsRunning = true;
        }

        public void Stop()
        {
            _animation.IsRunning = false;
        }
    }
}
