using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _3dProjectPrototype
{
    class Player : Sprite
    {
        public Projectile Projectile;

        public Player(Texture2D texture)
            :base(texture)
        {
            this.Hitbox = new Circle(Position, 10f);
        }

        public Vector2 getPosition()
        {
            return Position;
        }

        public override void Update(GameTime Gametime, List<Sprite> sprites)
        {
            //Key-release erkennen (Schussmechanik)
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();
        
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            { Position -= new Vector2(0, 1) * Speed; }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            { Position += new Vector2(0, 1) * Speed; }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            { Position -= new Vector2(1, 0) * Speed; }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            { Position += new Vector2(1, 0) * Speed; }

            Hitbox.setPosition(Position);


            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            { _rotation -= MathHelper.ToRadians(Rotationspeed); }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            { _rotation += MathHelper.ToRadians(Rotationspeed); }

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            //übertragen der werte in 3d
            modelPosition = new Vector3(Position.X, Position.Y, 0);
            world = Matrix.CreateTranslation(modelPosition);

            //Schiessen kreirt neue Projektile
            if (_currentKey.IsKeyDown(Keys.Space) && _previousKey.IsKeyUp(Keys.Space))
            {
                Shoot(sprites);
            }
        }

        private void Shoot(List<Sprite> sprites)
        {
            var projectile = Projectile.Clone() as Projectile;
            projectile.Direction = this.Direction;
            projectile.Position = this.Position;
            projectile.Speed = 10f;
            projectile.Speed = this.Speed * 2;
            projectile.LifeSpan = 1.5f;

            sprites.Add(projectile);
        }

    }
}
