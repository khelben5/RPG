using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class Animation
    {
        private readonly Dictionary<Direction, SpriteAnimation> _animations;
        private bool _isExecuting = false;

        public Direction Direction { get; set; }
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                if (!_isExecuting) ActiveAnimation.Stop();
            }
        }

        public Vector2 Position
        {
            get => ActiveAnimation.Position;
            set => ActiveAnimation.Position = value;
        }

        public Animation(SpriteAnimation animation) : this(animation, animation, animation, animation)
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
            Direction = Direction.Down;
            _isExecuting = false;
        }

        public void Update(GameTime gameTime)
        {
            if (_isExecuting) ActiveAnimation.Update(gameTime);
            else ActiveAnimation.Stop();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveAnimation.Draw(spriteBatch);
        }

        private SpriteAnimation ActiveAnimation { get => _animations[Direction]; }
    }
}
