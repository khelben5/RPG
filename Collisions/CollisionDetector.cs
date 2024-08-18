using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RPG
{
    class CollisionDetector
    {
        public static CollisionsResult DetectCollisions(
            List<Enemy> enemies,
            List<Projectile> projectiles,
            Player player
        )
        {
            List<Collision> collisions = new();

            foreach (Enemy enemy in enemies)
            {
                float distanceToPlayer = Vector2.Distance(player.Position, enemy.Position);
                if (distanceToPlayer < enemy.Radius + player.Radius)
                {
                    return new(
                        collidedWithPlayer: true,
                        collisions: new()
                    );
                }

                foreach (Projectile projectile in projectiles)
                {

                    float distance = Vector2.Distance(projectile.Position, enemy.Position);
                    if (distance < projectile.Radius + enemy.Radius)
                        collisions.Add(new(enemy, projectile));
                }
            }

            return new(
                collidedWithPlayer: false,
                collisions: collisions
            );
        }

        private CollisionDetector() { }
    }
}
