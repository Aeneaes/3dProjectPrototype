using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3dProjectPrototype
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Player player;
        private Texture2D _playerTexture;
        private bool won = true; //enables us to check if the skins are unlocked because the player won at least once
        public int enemyCount;
        private Enemy[] enemys = new Enemy[9];
        //maybe outsource later
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _playerTexture = Content.Load<Texture2D>("Images/Player");
            player = new Player(_playerTexture, new Vector2(400, 400), spriteBatch);


            enemys[0] = new Enemy(_playerTexture, new Vector2(400, 0), spriteBatch);
            enemys[1] = new Enemy(_playerTexture, new Vector2(300, -50), spriteBatch);
            enemys[2] = new Enemy(_playerTexture, new Vector2(500, -50), spriteBatch);
            enemys[3] = new Enemy(_playerTexture, new Vector2(200, -100), spriteBatch);
            enemys[4] = new Enemy(_playerTexture, new Vector2(600, -100), spriteBatch);
            enemys[5] = new Enemy(_playerTexture, new Vector2(100, -150), spriteBatch);
            enemys[6] = new Enemy(_playerTexture, new Vector2(700, -150), spriteBatch);
            enemys[7] = new Enemy(_playerTexture, new Vector2(0, -200), spriteBatch);
            enemys[8] = new Enemy(_playerTexture, new Vector2(800, -200), spriteBatch);
            //tried instancing enemys in a loop, but then only one enemy would get nstanced, TODO find efficent way

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            for (int i = 0; i < enemys.Length; i++) //update all enemys together
            {
                enemys[i].Update(gameTime, player.getPosition());
            }

            if (won) //skinselect
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    player.setSkin(Color.White);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    player.setSkin(Color.Green);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    player.setSkin(Color.Blue);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    player.setSkin(Color.Yellow);
                }
            }



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            player.Draw(gameTime);

            for (int i = 0; i < enemys.Length; i++) //Draw all enemys together
            {
                enemys[i].Draw(gameTime);
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
