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

        //Liste für Alle Entitäten, erleichtert Update/Draw Aufrufe
        private List<Sprite> _sprites;


        //maybe outsource later
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Vollbildfunktion
            graphics.IsFullScreen = true;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Spieler hat "vorne" grüne Markierung
            var playerTexture = Content.Load<Texture2D>("Images/Player");
            var enemyTexture = Content.Load<Texture2D>("Images/Enemy");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2(100, 100),
                    IsPlayer = true,
                    Projectile = new Projectile(Content.Load<Texture2D>("Images/projectile")),
                },
                new Enemy(enemyTexture)
                {
                    Position = new Vector2(0,0),
                    Speed = 1.5f
                },
                new Enemy(enemyTexture)
                {
                    Position = new Vector2(0,0),
                    Speed = 1f
                }
            };
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

            foreach(var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, _sprites);
            }
            
            //Projektile entfernen
            for(int i = 0; i < _sprites.Count; i++)
            {
                if(_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
