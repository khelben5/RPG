using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class State
    {
        private readonly Player _player;
        private readonly Camera _camera;
        private readonly Texture2D _projectileSprite;
        private readonly List<Projectile> _projectiles = new();

        private bool _isTriggerPulled = false;

        public Camera Camera { get => _camera; }

        public State(
            Camera camera,
            Player player,
            Texture2D projectileSprite
        )
        {
            _camera = camera;
            _player = player;
            _projectileSprite = projectileSprite;
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            UpdateCamera(gameTime);
            DetectShot();
            UpdateProjectiles(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawProjectiles(spriteBatch);
            _player.Draw(spriteBatch);
        }

        private void UpdateCamera(GameTime gameTime)
        {
            _camera.Position = _player.Position;
            _camera.Update(gameTime);
        }

        private void DetectShot()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !_isTriggerPulled)
            {
                _isTriggerPulled = true;
                _projectiles.Add(new(
                    sprite: _projectileSprite,
                    direction: _player.Direction,
                    position: _player.Position,
                    drawOffset: _player.Size / 2
                ));
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space)) _isTriggerPulled = false;
        }

        private void UpdateProjectiles(GameTime gameTime)
        {
            foreach (var projectile in _projectiles)
            {
                projectile.Update(gameTime);
            }
        }

        private void DrawProjectiles(SpriteBatch spriteBatch)
        {
            foreach (var projectile in _projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
