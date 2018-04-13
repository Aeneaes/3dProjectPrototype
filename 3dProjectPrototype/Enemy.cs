using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3dProjectPrototype
{
    class Enemy
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _direction;
        private bool alive;
        SpriteBatch _spriteBatch;

        public Enemy(Texture2D enemyTexture, Vector2 enemyPosition, SpriteBatch spriteBatch)
        {
            _texture = enemyTexture;
            _position = enemyPosition;
            _spriteBatch = spriteBatch;
            alive = true;
        }

        public void Update(GameTime Gametime, Vector2 playerPosition)
        {   
            if (alive)
            {
                _direction = Vector2.Subtract(playerPosition, _position);
                _direction = Vector2.Normalize(_direction); //devide or multiply this value to edit speed

                _position = Vector2.Add(_position, _direction); 
                //more precise tracking of the player

            }

            else { _position = new Vector2(-20, -20); }
        }

        public void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin();

            _spriteBatch.Draw(_texture, _position, Color.Red);

            _spriteBatch.End();
            // TODO: Add your drawing code here
        }
    }
}

