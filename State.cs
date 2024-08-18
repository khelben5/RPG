using System.Collections.Generic;
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
        private readonly EnemyController _enemyController;

        private bool _isTriggerPulled = false;

        public Camera Camera => _camera;

        public State(
            Camera camera,
            Player player,
            ProjectileFactory projectileFactory,
            EnemyController enemyController
        )
        {
            _camera = camera;
            _player = player;
            _projectileFactory = projectileFactory;
            _enemyController = enemyController;
        }

        public void Update(GameTime gameTime)
        {
            DetectCollisions();
            _player.Update(gameTime);
            UpdateCamera(gameTime);
            DetectShot();
            UpdateProjectiles(gameTime);
            UpdateEnemies(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawProjectiles(spriteBatch);
            _enemyController.Draw(spriteBatch);
            _player.Draw(spriteBatch);
        }

        private void DetectCollisions()
        {
            foreach (Collision collision in _enemyController.DetectCollisions(_projectiles))
            {
                _enemyController.KillEnemy(collision.enemy);
                _projectiles.Remove(collision.projectile);
            }
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
            foreach (Projectile projectile in _projectiles)
            {
                projectile.Update(gameTime);
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            _enemyController.SetPlayerPosition(_player.Position);
            _enemyController.Update(gameTime);
        }

        private void DrawProjectiles(SpriteBatch spriteBatch)
        {
            foreach (Projectile projectile in _projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
