using System;
using System.IO;
using Microsoft.Xna.Framework;

namespace RPG
{
    class EnemyPositionGenerator
    {
        private Vector2 _canvasSize;
        private float _enemyRadius;
        private Random _random;

        public EnemyPositionGenerator(Vector2 canvasSize, float enemyRadius)
        {
            _canvasSize = canvasSize;
            _enemyRadius = enemyRadius;
            _random = new Random();
        }

        public Vector2 Generate()
        {
            switch (RandomOrigin())
            {
                case Origin.Top:
                    return new(RandomX(), -_enemyRadius);
                case Origin.Bottom:
                    return new(RandomX(), _canvasSize.Y + _enemyRadius);
                case Origin.Left:
                    return new(-_enemyRadius, RandomY());
                case Origin.Right:
                    return new(_canvasSize.X + _enemyRadius, RandomY());
                default:
                    throw new RPGException("Never gonna happen!");
            }
        }

        private Origin RandomOrigin()
        {
            Array values = Enum.GetValues(typeof(Origin));
            return (Origin)values.GetValue(Random.Shared.Next(values.Length));
        }

        private int RandomX() => _random.Next((int)_canvasSize.X);

        private int RandomY() => _random.Next((int)_canvasSize.Y);

        private enum Origin { Top, Bottom, Left, Right }
    }
}
