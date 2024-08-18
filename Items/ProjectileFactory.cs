using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class ProjectileFactory
    {
        private readonly Texture2D _sprite;

        public ProjectileFactory(Texture2D sprite)
        {
            _sprite = sprite;
        }

        public Projectile create(
            Vector2 position,
            Direction direction
        ) => new(_sprite, direction, position);
    }
}
