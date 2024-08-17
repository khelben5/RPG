using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class PlayerAnimations
    {
        private readonly SpriteAnimation _walkDown;
        private readonly SpriteAnimation _walkUp;
        private readonly SpriteAnimation _walkRight;
        private readonly SpriteAnimation _walkLeft;

        public PlayerAnimations(
            SpriteAnimation walkDown,
            SpriteAnimation walkUp,
            SpriteAnimation walkRight,
            SpriteAnimation walkLeft
        )
        {
            _walkDown = walkDown;
            _walkUp = walkUp;
            _walkRight = walkRight;
            _walkLeft = walkLeft;
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            _walkDown.Position = new(
                position.X - _walkDown.Width / 2,
                position.Y - _walkDown.Height / 2
            );
            _walkDown.Update(gameTime);
            // _walkUp.Update(gameTime);
            // _walkRight.Update(gameTime);
            // _walkLeft.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _walkDown.Draw(spriteBatch);
            // _walkUp.Draw(spriteBatch);
            // _walkRight.Draw(spriteBatch);
            // _walkLeft.Draw(spriteBatch);
        }
    }
}
