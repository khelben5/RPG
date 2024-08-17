using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class PlayerAnimations
    {
        private readonly Dictionary<Direction, SpriteAnimation> _animations;

        private Direction _direction;
        private bool _isRunning = false;

        public bool IsRunning { get => _isRunning; set => _isRunning = value; }

        public PlayerAnimations(
            SpriteAnimation walkDown,
            SpriteAnimation walkUp,
            SpriteAnimation walkRight,
            SpriteAnimation walkLeft
        )
        {
            _animations = new()
            {
                { Direction.Down, walkDown },
                { Direction.Up, walkUp },
                { Direction.Right, walkRight },
                { Direction.Left, walkLeft }
            };
        }

        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            ActiveAnimation.Position = new(
                position.X - ActiveAnimation.Width / 2,
                position.Y - ActiveAnimation.Height / 2
            );

            if (_isRunning) ActiveAnimation.Update(gameTime);
            else ActiveAnimation.Stop();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ActiveAnimation.Draw(spriteBatch);
        }

        private SpriteAnimation ActiveAnimation { get => _animations[_direction]; }
    }
}
