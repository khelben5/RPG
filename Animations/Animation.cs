using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class Animation
    {
        private readonly Dictionary<Direction, SpriteAnimation> _animations;

        public Vector2 Position
        {
            get => ActiveAnimation.Position;
            set => ActiveAnimation.Position = value;
        }
        public Direction Direction { get; set; }
        public bool IsExecuting = false;

        public Animation(
            SpriteAnimation animation
        ) : this(animation, animation, animation, animation)
        { }

        public Animation(
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

        public void Update(GameTime gameTime)
        {
            if (IsExecuting) ActiveAnimation.Update(gameTime);
            else ActiveAnimation.Stop();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveAnimation.Draw(spriteBatch);
        }

        private SpriteAnimation ActiveAnimation { get => _animations[Direction]; }
    }
}
