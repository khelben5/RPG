using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    struct PlayerSprites
    {
        public Texture2D Player;
        public Texture2D WalkDown;
        public Texture2D WalkUp;
        public Texture2D WalkRight;
        public Texture2D WalkLeft;

        public PlayerSprites(
            Texture2D player,
            Texture2D walkDown,
            Texture2D walkUp,
            Texture2D walkRight,
            Texture2D walkLeft)
        {
            Player = player;
            WalkDown = walkDown;
            WalkUp = walkUp;
            WalkRight = walkRight;
            WalkLeft = walkLeft;
        }
    }
}
