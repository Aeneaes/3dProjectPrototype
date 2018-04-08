using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3dProjectPrototype
{
    class Player
    {
        private Texture2D _texture;
        private Vector2 _position;
        SpriteBatch _spriteBatch;

        public Player(Texture2D playerTexture, Vector2 playerPosition, SpriteBatch spriteBatch)
        {
            _texture = playerTexture;
            _position = playerPosition;
            _spriteBatch = spriteBatch;
        }
        public Vector2 getPosition()
        {
            return _position;
        }
        public void Update(GameTime Gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            { _position = Vector2.Add(_position, new Vector2(0, -5)); }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            { _position = Vector2.Add(_position, new Vector2(0, 5)); }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            { _position = Vector2.Add(_position, new Vector2(-5, 0)); }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            { _position = Vector2.Add(_position, new Vector2(5, 0)); }
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
