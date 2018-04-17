using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dProjectPrototype
{
    public class Projectile : Sprite
    {
        private float _timer;
        public Projectile(Texture2D texture)
            : base(texture)
        {
            this.Hitbox = new Circle(Position, 5f); //TODO Sinnvolle Hitboxgrößen
        }

        public override void Update(GameTime gameTime, List<Sprite> sprite)
        {
            //Zeit wie lange Projektil existiert
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Projektiel Entfernen wenn Lebenszeit abläuft
            if (_timer > LifeSpan)
            {
                IsRemoved = true;
            }

            Position += Direction * Speed;
            Hitbox.setPosition(Position);

            //Enemys und Projektil entfernen wenn ein gegner getroffen wird
            foreach (var player in sprite)
            {
                if (player.IsEnemy)
                    if (player.Hitbox.intersectsWith(Hitbox))
                    {
                        IsRemoved = true;
                        player.IsRemoved = true;
                    }
                    
            }
        }
        
    }
}
