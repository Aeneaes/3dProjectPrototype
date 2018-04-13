using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3dProjectPrototype
{
    class Enemy : Sprite
    {
        private Vector2 _playerPos;

        public Enemy(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprite)
        {
            GetPlayerPos(sprite);
            MoveTowardsPlayer(_playerPos);
        }

        //Speed für verschiedene Gegner
        private void MoveTowardsPlayer(Vector2 playerPos)
        {
            if (playerPos.Y < this.Position.Y)
            { Position = Vector2.Add(Position, new Vector2(0, -3 * this.Speed)); }

            if (playerPos.Y > this.Position.Y)
            { Position = Vector2.Add(Position, new Vector2(0, 3*this.Speed)); }

            if (playerPos.X < Position.X)
            { Position = Vector2.Add(this.Position, new Vector2(-3 * this.Speed, 0)); }

            if (playerPos.X > this.Position.X)
            { Position = Vector2.Add(Position, new Vector2(3 * this.Speed, 0)); }
        }

        private void GetPlayerPos(List<Sprite> sprite)
        {
            foreach(var player in sprite)
            {
                if(player.IsPlayer)
                _playerPos = player.Position;
            }
        }
    }
}

