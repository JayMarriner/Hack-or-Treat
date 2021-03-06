﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameContent gameContent;
        private int screenWidth = 0;
        private int screenHeight = 0;
        public List<Player> players = new List<Player>();
        public List<Wall> walls = new List<Wall>();
        public List<Background> backgrounds = new List<Background>();
        public List<Npc> npcs = new List<Npc>();
        //public List<Knife> knives = new List<Knife>();
        public List<Enemy> enemies = new List<Enemy>();
        private static Texture2D _blankTexture;

        public SpriteFont npcText { get; private set; }

        public static Texture2D BlankTexture(SpriteBatch s)
        {
            if (_blankTexture == null)
            {
                _blankTexture = new Texture2D(s.GraphicsDevice, 1, 1);
                //_blankTexture.SetData(new[] { Color.Red });
            }
            return _blankTexture;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            // TODO: use this.Content to load your game content here
            gameContent = new GameContent(Content);
            screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            if(screenWidth >= 1920)
            {
                screenWidth = 1920;
            }
            if(screenHeight >= 1080)
            {
                screenHeight = 1080;
            }
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            //Create player
            int playerX = (gameContent.player.Width / 2) + 50;
            int playerY = screenHeight - (gameContent.player.Height / 2) - 50;
            players.Add(new Player(playerX, playerY, screenWidth, screenHeight, spriteBatch, gameContent, 5));

            //Create walls
            //Level 1
            walls.Add(new Wall(100, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(175, 625, spriteBatch, gameContent, true));
            walls.Add(new Wall(175, 825, spriteBatch, gameContent, true));
            walls.Add(new Wall(300, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(500, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(700, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(775, 375, spriteBatch, gameContent, true));
            walls.Add(new Wall(775, 175, spriteBatch, gameContent, true));
            walls.Add(new Wall(900, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(1100, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(1300, 500, spriteBatch, gameContent, false));
            walls.Add(new Wall(1500, 500, spriteBatch, gameContent, false));

            //Create background
            backgrounds.Add(new Background(0, 0, 1080, 1920, spriteBatch, gameContent));

            //NPC
            npcs.Add(new Npc(100, 400, spriteBatch, gameContent, 3, 500));

            //Knife
            //knives.Add(new Knife(50, 380, spriteBatch, gameContent, 2));

            //Enemy
            enemies.Add(new Enemy(700, 650, spriteBatch, gameContent, 100));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            players.ForEach(x => x.movementUpdate());
            players.ForEach(x => x.Update(walls));
            players.ForEach(x => x.Update(npcs));
            npcs.ForEach(x => x.Update());
            npcs.ForEach(x => x.Update(players));
            enemies.ForEach(x => x.Update());
            enemies.ForEach(x => x.Update(players));
            players.ForEach(x => x.attackUpdate(enemies));
            //knives.ForEach(x => x.Update());
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            backgrounds.ForEach(x => x.Draw());
            players.ForEach(x => x.Draw());
            walls.ForEach(x => x.Draw());
            npcs.ForEach(x => x.Draw());
            //knives.ForEach(x => x.Draw());
            enemies.ForEach(x => x.Draw());
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
