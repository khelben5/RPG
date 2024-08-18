using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class AnimationLoader
    {
        public static SpriteAnimation LoadPlayer(
            ContentManager contentManager,
            string assetName
        ) => Load(contentManager, assetName, 4, 8);

        public static SpriteAnimation LoadEnemy(
            ContentManager contentManager,
            string assetName
        ) => Load(contentManager, assetName, 10, 6);

        private static SpriteAnimation Load(
            ContentManager contentManager,
            string assetName,
            int numberOfFrames,
            int framesPerSecond
        ) => new(contentManager.Load<Texture2D>(assetName), numberOfFrames, framesPerSecond);

        private AnimationLoader() { }
    }
}
