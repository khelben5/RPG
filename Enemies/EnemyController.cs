using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class EnemyController
    {
        private readonly EnemyFactory _factory;
        private readonly EnemyPositionGenerator _positionGenerator;
        private readonly List<Enemy> _enemies;

        private double _maxTimer = 2;
        private double _timer;
        private Vector2 _playerPosition;

        public List<Enemy> Enemies => _enemies;

        public EnemyController(
            EnemyFactory factory,
            EnemyPositionGenerator positionGenerator
        )
        {
            _factory = factory;
            _positionGenerator = positionGenerator;
            _enemies = new();
            _timer = _maxTimer;
        }

        public void Update(GameTime gameTime)
        {
            GenerateNewEnemies(gameTime);
            UpdateEnemies(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public void SetPlayerPosition(Vector2 position)
        {
            _playerPosition = position;
        }

        public void KillEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public List<Collision> DetectCollisions(List<Projectile> projectiles) =>
            CollisionDetector.DetectCollisions(_enemies, projectiles);

        private void GenerateNewEnemies(GameTime gameTime)
        {
            _timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer <= 0)
            {
                _enemies.Add(_factory.create(
                    _positionGenerator.Generate(),
                    _playerPosition
                ));
                _timer = _maxTimer;

                if (_maxTimer > 0.5) _maxTimer -= 0.05;
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.SetTargetPosition(_playerPosition);
                enemy.Update(gameTime);
            }
        }
    }
}
