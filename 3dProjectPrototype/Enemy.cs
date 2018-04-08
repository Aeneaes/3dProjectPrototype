using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3dProjectPrototype
{
    class Enemy
    {
            private Texture2D _texture;
            private Vector2 _position;
            SpriteBatch _spriteBatch;

            public Enemy(Texture2D enemyTexture, Vector2 enemyPosition, SpriteBatch spriteBatch)
            {
                _texture = enemyTexture;
                _position = enemyPosition;
                _spriteBatch = spriteBatch;
            }

            public void Update(GameTime Gametime, Vector2 playerPosition)
            {
                if (playerPosition.Y < _position.Y)
                { _position = Vector2.Add(_position, new Vector2(0, -3)); }

                if (playerPosition.Y > _position.Y)
                { _position = Vector2.Add(_position, new Vector2(0, 3)); }

                if (playerPosition.X < _position.X)
                { _position = Vector2.Add(_position, new Vector2(-3, 0)); }

                if (playerPosition.X > _position.X)
                { _position = Vector2.Add(_position, new Vector2(3, 0)); }
            }

            public void Draw(GameTime gameTime)
            {

                _spriteBatch.Begin();

                _spriteBatch.Draw(_texture, _position, Color.White);

                _spriteBatch.End();
                // TODO: Add your drawing code here
            }
        }
    }

