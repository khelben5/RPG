using Microsoft.Xna.Framework.Graphics;

struct GameSprites
{
    public PlayerSprites Player;
    public Texture2D Background;
    public Texture2D Ball;
    public Texture2D Skull;

    public GameSprites(
        PlayerSprites player,
        Texture2D background,
        Texture2D ball,
        Texture2D skull
    )
    {
        Player = player;
        Background = background;
        Ball = ball;
        Skull = skull;
    }
}
