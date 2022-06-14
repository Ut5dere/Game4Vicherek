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

        public Sprite(Texture2D obr)
        {
            this.obrazek = obr;
        }

        public Rectangle Obdelnik
        {
            get { return new Rectangle((int)pozice.X, (int)pozice.Y, obrazek.Width, obrazek.Height); }
        }

        public virtual void Update(GameTime gameTime,List<Sprite>sprites, Player player)
        {
            if(player.Obdelnik.Intersects(this.Obdelnik) && (this is Wall))
            {
                if (player.Velocity.X == -1){

                }
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(obrazek, pozice, Color.White);
        }
    }
}
