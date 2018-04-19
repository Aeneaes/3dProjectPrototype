using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3dProjectPrototype
{   
    //Überklasse für alle Entitäten um Vererbung auszunutzen
    public class Sprite : ICloneable
    {
        #region Properties
        protected Texture2D _texture;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

       

        public Vector2 Position;
        public Vector2 Origin;

        public Vector2 Direction;
        public float Speed = 8f;
        public float Rotationspeed = 4f;

        //für ggf. Multiplayer
        public Input Input;

        public float LifeSpan = 0f;
        public bool IsRemoved = false;
        public bool IsPlayer = false;
        public bool IsEnemy = false;

        public Circle Hitbox;
        //einfachere Kollision
        #endregion

        //eventuell für Kollision brauchbar
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }

        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprite)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);
        }

        //Projektile sind Objekte mit Referenzen, daher treten Probleme auf wenn man sie nicht klont
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
