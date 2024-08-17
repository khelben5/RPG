using System;
using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class State
    {
        private readonly Player _player;
        private readonly Camera _camera;

        public Camera Camera { get => _camera; }

        public State(Camera camera, Player player)
        {
            _camera = camera;
            _player = player;
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            _camera.Position = _player.Position;
            _camera.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
        }
    }
}
