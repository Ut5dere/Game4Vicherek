using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game4B
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random = new Random();
        List<Sprite> sprites = new List<Sprite>();
        Texture2D obrazekSprite;
        Texture2D obrazekPlayer;
        Texture2D obrazekWall;
        bool prekryti;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //nastavení velikosti herního okna
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            obrazekPlayer = Content.Load<Texture2D>("rex");
            obrazekSprite = Content.Load<Texture2D>("bird");
            obrazekWall = Content.Load<Texture2D>("wall");
            //definice pole stringů s 12ti prvky
            string[] mapa = new string[12];
            mapa = File.ReadAllLines("mapa.txt");
            int m = 0;
            int n = 0;
            foreach(string s in mapa)
            {
                n = 0;
                foreach(char z in s)
                {
                    if(z=='1')
                    {
                        Wall wall = new Wall(obrazekWall);
                        wall.pozice = new Vector2(n * 50, m * 50);
                        sprites.Add(wall);
                    }
                    n++;
                }
                m++;
            }

            //generování spritů
            for (int i = 0; i < 5; i++)
            {
                prekryti = false;
                Sprite sprite = new Sprite(obrazekSprite);
                sprite.pozice = new Vector2(random.Next(800), random.Next(600));
                foreach (Sprite s in sprites)
                {
                    if (sprite.Obdelnik.Intersects(s.Obdelnik))
                        prekryti = true;
                }
                    if (prekryti == false) sprites.Add(sprite);
                    if (prekryti == true) i--;
                
            }

            //generování hráče
            player = new Player(obrazekPlayer);
            player.pozice = new Vector2(50, 450);
            sprites.Add(player);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (Sprite s in sprites)
                s.Update(gameTime, sprites, player);
            for(int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i].odstranen)
                {
                    sprites.RemoveAt(i);
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (Sprite s in sprites)
                s.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
