using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class MovingAnimation
    {
        private readonly Dictionary<Direction, SpriteAnimation> _animations;

        public Direction Direction { get; set; }
        public Vector2 Size { get => ActiveAnimation.Size; }

        public bool IsRunning;

        public MovingAnimation(
            SpriteAnimation moveDown,
            SpriteAnimation moveUp,
            SpriteAnimation moveRight,
            SpriteAnimation moveLeft
        )
        {
            _animations = new()
            {
                { Direction.Down, moveDown },
                { Direction.Up, moveUp },
                { Direction.Right, moveRight },
                { Direction.Left, moveLeft }
            };
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            ActiveAnimation.Position = position - ActiveAnimation.Size / 2;
            if (IsRunning) ActiveAnimation.Update(gameTime);
            else ActiveAnimation.Stop();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveAnimation.Draw(spriteBatch);
        }

        private SpriteAnimation ActiveAnimation { get => _animations[Direction]; }
    }
}
