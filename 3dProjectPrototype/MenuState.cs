using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3dProjectPrototype
{
    public class MenuState : State
    {
        SpriteFont textFont ;
        private List<Component> _components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Images/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            textFont = _content.Load<SpriteFont>("Fonts/Font");

            var startButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Start",
            };

            startButton.Click += StartButton_Click;

            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 260),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;

            _components = new List<Component>()
            {
                startButton,
                quitButton,
            };
        }


        private void QuitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Game1.win = false;
            Game1.loose = false;
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            if (Game1.win)
            {
                spriteBatch.DrawString(textFont, "Nice! You Won some new Skins! (Choose via NumPad)", new Vector2(100, 100), Color.Black);
            }
            else if (Game1.loose)
            {
                spriteBatch.DrawString(textFont, "You Failed! Might wanna try again...", new Vector2(100, 100), Color.Black);
            }
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Eventuell Sachen im Menü entfernen
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}

