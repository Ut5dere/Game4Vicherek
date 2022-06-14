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
    class Player : Sprite
    {
        //informace o směru pohybu hráče
        public Vector2 Velocity;
        public Player(Texture2D obr) : base(obr)
        {
            obrazek = obr;
            Velocity = Vector2.Zero;

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites, Player player)
        {
            if (Velocity.Y == 0)
            {


                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    pozice.X -= 5;
                    Velocity.X = -1;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    pozice.X += 5;
                    Velocity.X = 1;
                }
                else
                {
                    Velocity.X = 0;
                }
            }
            if (Velocity.X == 0)
            {


                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    pozice.Y -= 5;
                    Velocity.Y = -1;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    pozice.Y += 5;
                    Velocity.Y = 1;
                }
                else
                {
                    Velocity.Y = 0;
                }
            }
        }

    }
}
