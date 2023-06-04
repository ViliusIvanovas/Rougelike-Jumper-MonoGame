using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rougelike_Jumper_MonoGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Player Player = new Player(100, new Vector2(0, 0));

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
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

        for (int i = 0; i < Player.IdleTextures.Length; i++)
        {
            Player.IdleTextures[i] = Content.Load<Texture2D>($"Player/Idle{i}");
        }

        Player.AnimationTextures.Add("Idle", Player.IdleTextures);

        Player.CurrentAnimationIndex = 0;
    }

    public float TimeSinceAnimationChange = 0;

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

        TimeSinceAnimationChange += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (TimeSinceAnimationChange > 3f)
        {
            TimeSinceAnimationChange = 0;
            Player.CurrentAnimationIndex++;
            if (Player.CurrentAnimationIndex >= Player.AnimationTextures["Idle"].Length)
            {
                Player.CurrentAnimationIndex = 0;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(Player.AnimationTextures["Idle"][Player.CurrentAnimationIndex], Player.Position, Color.White);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
