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
    class Wall:Sprite
    {
        public Wall(Texture2D obr):base(obr)
        {
           obrazek = obr;
        }
    }
}
