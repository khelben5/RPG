using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Player
    {
        private readonly int _speed = 300;
        private readonly PlayerAnimations _animations;

        private Vector2 _position = new(500, 300);
        private Direction _direction = Direction.Down;

        public Vector2 Position { get => _position; }

        public Player(PlayerAnimations animations)
        {
            _animations = animations;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (IsKeyDown(Keys.Right)) MoveRight(deltaTime);
            if (IsKeyDown(Keys.Left)) MoveLeft(deltaTime);
            if (IsKeyDown(Keys.Down)) MoveDown(deltaTime);
            if (IsKeyDown(Keys.Up)) MoveUp(deltaTime);

            _animations.Update(gameTime, _position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animations.Draw(spriteBatch);
        }

        private bool IsKeyDown(Keys key) => Keyboard.GetState().IsKeyDown(key);

        private void MoveRight(float deltaTime)
        {
            _direction = Direction.Right;
            _position.X += _speed * deltaTime;
        }

        private void MoveLeft(float deltaTime)
        {
            _direction = Direction.Left;
            _position.X -= _speed * deltaTime;
        }

        private void MoveDown(float deltaTime)
        {
            _direction = Direction.Down;
            _position.Y += _speed * deltaTime;
        }

        private void MoveUp(float deltaTime)
        {
            _direction = Direction.Up;
            _position.Y -= _speed * deltaTime;
        }
    }
}
