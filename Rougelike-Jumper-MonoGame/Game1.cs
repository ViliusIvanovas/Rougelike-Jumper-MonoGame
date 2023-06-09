using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rougelike_Jumper_MonoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Player Player = new Player(new Vector2 (2, 2));

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 400;
        _graphics.PreferredBackBufferHeight = 800;
        
        _graphics.ApplyChanges();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        #region Load Player Textures

        for (int i = 0; i < Player.IdleTextures.Length; i++)
        {
            Texture2D texture2D = Content.Load<Texture2D>($"Player/Idle{i}");
            Player.IdleTextures[i] = texture2D;
        }

        Player.AnimationTextures.Add("Idle", Player.IdleTextures);

        Player.CurrentAnimationIndex = 0;

        #endregion
    }

    protected override void Update(GameTime gameTime)
    {
        #region Controls

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
            Player.Position += new Vector2(1, 0);
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
            Player.Position += new Vector2(-1, 0);
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up))
            Player.Position += new Vector2(0, -1);
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down))
            Player.Position += new Vector2(0, 1);

        #endregion

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(Player.AnimationTextures[Player.CurrentAnimationState][Player.CurrentAnimationIndex], Player.Position, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
