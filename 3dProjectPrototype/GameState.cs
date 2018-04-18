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
    public class GameState : State
    {
        //Liste für Alle Entitäten, erleichtert Update/Draw Aufrufe
        private List<Sprite> _sprites;
        //test
        private Model playermodel;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            playermodel = _content.Load<Model>("Images/test");
            Game1.enemyCount = 3;

            //Spieler hat "vorne" grüne Markierung
            var playerTexture = _content.Load<Texture2D>("Images/Player");
            var enemyTexture = _content.Load<Texture2D>("Images/Enemy");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2(200, 200),
                    IsPlayer = true,
                    Projectile = new Projectile(_content.Load<Texture2D>("Images/projectile")),
                },
                new Enemy(enemyTexture)
                {
                    Position = new Vector2(100,100),
                    IsEnemy = true,
                    Speed = 1.5f
        },
                new Enemy(enemyTexture)
                {
                    Position = new Vector2(300,300),
                    IsEnemy = true,
                    Speed = 1f
                }
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();

            //test
            foreach (var sprite in _sprites)
                DrawModel(playermodel, sprite.world, sprite.view, sprite.projection);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, _sprites);
            }

            //Projektile entfernen
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
            //Spieler gewinnt wenn er als letter steht ergo der einzige übrige sprite ist
            if (_sprites.Count == 1)
            {
                Game1.win = true;
                Game1.skinsUnlocked = true;
            }


            if(Game1.win || Game1.loose) _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));

        }
    }
}
