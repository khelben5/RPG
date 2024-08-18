using System.Collections.Generic;

namespace RPG
{
    struct CollisionsResult
    {
        public bool collidedWithPlayer;
        public List<Collision> collisions;

        public CollisionsResult(
            bool collidedWithPlayer,
            List<Collision> collisions
        )
        {
            this.collidedWithPlayer = collidedWithPlayer;
            this.collisions = collisions;
        }
    }
}
