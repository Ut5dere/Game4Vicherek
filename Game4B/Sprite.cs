using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game4B
{
    class Sprite
    {
        public Vector2 pozice;
        protected Texture2D obrazek;
        public bool odstranen;

        public Sprite(Texture2D obr)
        {
            this.obrazek = obr;
        }

        public Rectangle Obdelnik
        {
            get { return new Rectangle((int)pozice.X, (int)pozice.Y, obrazek.Width, obrazek.Height); }
        }

        public virtual void Update(GameTime gameTime,List<Sprite>sprites,Player player)
        {
            //interakce zdi a hráče
            if(player.Obdelnik.Intersects(this.Obdelnik)&& (this is Wall))
            {
                if (player.Velocity.X == -1)
                    player.pozice.X = this.Obdelnik.Right;
                if (player.Velocity.X == 1)
                    player.pozice.X = this.Obdelnik.Left-player.obrazek.Width;
                if (player.Velocity.Y == -1)
                    player.pozice.Y = this.Obdelnik.Bottom;
                if (player.Velocity.Y == 1)
                    player.pozice.Y = this.Obdelnik.Top-player.obrazek.Height;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(obrazek, pozice, Color.White);
        }
    }
}
