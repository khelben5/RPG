using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RPG
{
    class CollisionDetector
    {
        public static List<Collision> DetectCollisions(
            List<Enemy> enemies,
            List<Projectile> projectiles
        )
        {
            List<Collision> collisions = new();
            foreach (Projectile projectile in projectiles)
            {
                foreach (Enemy enemy in enemies)
                {
                    float distance = Vector2.Distance(projectile.Position, enemy.Position);
                    if (distance < projectile.Radius + enemy.Radius)
                        collisions.Add(new(enemy, projectile));
                }
            }
            return collisions;
        }

        private CollisionDetector() { }
    }
}
