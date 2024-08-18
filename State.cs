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
        private readonly ProjectileFactory _projectileFactory;
        private readonly List<Projectile> _projectiles = new();
        private readonly List<Enemy> _enemies = new();

        private bool _isTriggerPulled = false;

        public Camera Camera { get => _camera; }

        public State(
            Camera camera,
            Player player,
            ProjectileFactory projectileFactory,
            EnemyFactory enemyFactory
        )
        {
            _camera = camera;
            _player = player;
            _projectileFactory = projectileFactory;
            _enemies.Add(enemyFactory.create(new(10, 10), _player.Position));
            _enemies.Add(enemyFactory.create(new(300, 300), _player.Position));
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            UpdateCamera(gameTime);
            DetectShot();
            UpdateProjectiles(gameTime);
            UpdateEnemies(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawProjectiles(spriteBatch);
            DrawEnemies(spriteBatch);
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
                _projectiles.Add(_projectileFactory.create(
                    position: _player.Position,
                    direction: _player.Direction
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

        private void UpdateEnemies(GameTime gameTime)
        {
            foreach (var enemy in _enemies)
            {
                enemy.SetTargetPosition(_player.Position);
                enemy.Update(gameTime);
            }
        }

        private void DrawProjectiles(SpriteBatch spriteBatch)
        {
            foreach (var projectile in _projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        private void DrawEnemies(SpriteBatch spriteBatch)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
