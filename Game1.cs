using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_battle
{
    public class Game1 : Game
    {
       private Texture2D playerTexture;
        private Vector2 playerPostion;
        private float playerSpeed;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerPostion = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            playerSpeed = 200f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("player");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up))
            {
                playerPostion.Y -= playerSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down))
            {
                playerPostion.Y += playerSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left))
            {
                playerPostion.X -= playerSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right))
            {
                playerPostion.X += playerSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(playerTexture, playerPostion, null, Color.White, 0f,
                new Vector2(playerTexture.Width / 2, playerTexture.Height / 2),
                0.3f, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}