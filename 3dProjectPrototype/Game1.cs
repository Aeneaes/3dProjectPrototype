using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3dProjectPrototype
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        private State _currentState;
        private State _nextState;

        private Texture2D activeBackground;
        private Texture2D standartBackground;
        private Texture2D alternativeBackground;

        public static bool skinsUnlocked = false;
        public static bool win = false;
        public static bool loose = false;

        public static int enemyCount;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        //maybe outsource later
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Vollbildfunktion
            graphics.IsFullScreen = false;
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
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            standartBackground = Content.Load<Texture2D>("Images/space");
            alternativeBackground = Content.Load<Texture2D>("Images/earth");
            activeBackground = standartBackground;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);

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

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            if (skinsUnlocked)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.NumPad1)) activeBackground = standartBackground;
                if (Keyboard.GetState().IsKeyDown(Keys.NumPad2)) activeBackground = alternativeBackground;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            if (win)
            {
                GraphicsDevice.Clear(Color.ForestGreen);
            }
            else if(loose)
            {
                GraphicsDevice.Clear(Color.DarkRed);
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(activeBackground, new Rectangle(0, 0, 800, 480), Color.White);
                spriteBatch.End();
            }
            
            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }

    }
}