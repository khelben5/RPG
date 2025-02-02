using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    class EnemyFactory
    {
        private readonly WeakReference<ContentManager> _contentManager;

        public EnemyFactory(ContentManager contentManager)
        {
            _contentManager = new(contentManager);
        }

        public Enemy create(
            Vector2 initialPosition,
            Vector2 initialTargetPosition
        )
        {
            ContentManager content;
            bool contentManagerAvailable = _contentManager.TryGetTarget(out content);
            if (!contentManagerAvailable)
                throw new RpgException("No reference to content manager.");
            return new(
                initialPosition,
                initialTargetPosition,
                AnimationLoader.LoadEnemy(content, "skull")
            );
        }
    }
}
