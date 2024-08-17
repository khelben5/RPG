using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG;

public class RpgGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameSprites _sprites;
    private State _state;

    public RpgGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        SetUpCanvasSize();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _sprites = CreateGameSprites();
        _state = new(
            camera: new(_graphics.GraphicsDevice),
            player: new(LoadDirectedAnimation()),
            projectileSprite: _sprites.Ball
        );
    }

    protected override void Update(GameTime gameTime)
    {
        ExitIfRequired();
        _state.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin(_state.Camera);
        _spriteBatch.Draw(_sprites.Background, new Vector2(-500, -500), Color.White);
        _state.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }

    private void SetUpCanvasSize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();
    }

    private GameSprites CreateGameSprites() => new(
        player: CreatePlayerSprites(),
        background: Content.Load<Texture2D>("background"),
        ball: Content.Load<Texture2D>("ball"),
        skull: Content.Load<Texture2D>("skull")
    );

    private PlayerSprites CreatePlayerSprites() => new(
        player: Content.Load<Texture2D>("Player/player"),
        walkDown: Content.Load<Texture2D>("Player/walkDown"),
        walkUp: Content.Load<Texture2D>("Player/walkUp"),
        walkRight: Content.Load<Texture2D>("Player/walkRight"),
        walkLeft: Content.Load<Texture2D>("Player/walkLeft")
    );

    private MovingAnimation LoadDirectedAnimation() => new(
        moveDown: LoadAnimation("Player/walkDown"),
        moveUp: LoadAnimation("Player/walkUp"),
        moveRight: LoadAnimation("Player/walkRight"),
        moveLeft: LoadAnimation("Player/walkLeft")
    );

    private SpriteAnimation LoadAnimation(
        string assetName,
        int numberOfFrames = 4,
        int framesPerSecond = 8
    ) => new(Content.Load<Texture2D>(assetName), numberOfFrames, framesPerSecond);

    private void ExitIfRequired()
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
    }
}
