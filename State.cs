using System;
using Microsoft.Xna.Framework;

namespace RPG
{
    class State
    {
        private Player _player = new();

        public Vector2 GetPlayerPosition() => _player.Position;

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }
    }
}
