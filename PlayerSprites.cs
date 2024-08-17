using Microsoft.Xna.Framework.Graphics;

struct PlayerSprites
{
    Texture2D Player;
    Texture2D WalkDown;
    Texture2D WalkUp;
    Texture2D WalkRight;
    Texture2D WalkLeft;

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
