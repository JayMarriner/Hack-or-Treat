﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Draw = System.Drawing;

namespace Game1
{
    public class Player
    {
        public int X { get; set; } //Players x coord
        public int Y { get; set; } //Players y coord
        public int width { get; set; } //Players width
        public int height { get; set; } //Players height
        public float screenWidth { get; set; } //Width of screen
        public float screenHeight { get; set; } //Height of screen
        private Texture2D player { get; set; } //Player image
        public int Speed { get; set; }
        private SpriteBatch spriteBatch;
        private bool wallHit;
        private int newPosX;
        private int newPosY;

        public Player(int x, int y, float screenW, float screenH, SpriteBatch spriteBatch, GameContent gameContent, int speed)
        {
            X = x;
            Y = y;
            newPosX = X;
            newPosY = Y;
            player = gameContent.player;
            width = player.Width;
            height = player.Height;
            this.spriteBatch = spriteBatch;
            screenWidth = screenWidth + (player.Width / 2);
            screenHeight = screenHeight + (player.Height / 2);
            Speed = speed;
        }

        public void Draw()
        {
            float Xcentre = height / 2;
            float Ycentre = width / 2;
            spriteBatch.Draw(player, new Vector2(X, Y), null, Color.White, 0, new Vector2(Xcentre, Ycentre), 1.0f, SpriteEffects.None, 0);
        }

        public Rectangle hitBox => new Rectangle(newPosX, newPosY, width, height);

        public void Update(List<Wall> walls)
        {
            walls.ForEach(x => {
                if (this.hitBox.Intersects(x.hitBox))
                {
                    return;
                }
                else
                {
                    X = newPosX;
                    Y = newPosY;
                }
            });
        }

        public void movementUpdate()
        {
            KeyboardState keyPress = Keyboard.GetState();
            if (keyPress.IsKeyDown(Keys.W))
            {
                newPosY = Y - Speed;
            }
        }
    }
}
