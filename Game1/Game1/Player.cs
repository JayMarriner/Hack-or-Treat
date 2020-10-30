using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Player
    {
        public float X { get; set; } //Players x coord
        public float Y { get; set; } //Players y coord
        public float width { get; set; } //Players width
        public float height { get; set; } //Players height
        public float screenWidth { get; set; } //Width of screen
        public float screenHeight { get; set; } //Height of screen
        private Texture2D player { get; set; } //Player image
        public int Speed { get; set; }
        private SpriteBatch spriteBatch;

        public Player(float x, float y, float screenW, float screenH, SpriteBatch spriteBatch, GameContent gameContent, int speed)
        {
            X = x;
            Y = y;
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

        public void Update()
        {
            KeyboardState keyPress = Keyboard.GetState();
            if (keyPress.IsKeyDown(Keys.D))
            {
                for (int i = 0; i < Speed; i++)
                {
                    if (X >= 1920 - width / 2)
                    {
                        return;
                    }
                    else
                    {
                        X++;
                    }
                }
            }
            if (keyPress.IsKeyDown(Keys.A))
            {
                for (int i = 0; i < Speed; i++)
                {
                    if (X <= 0 + width / 2)
                    {
                        return;
                    }
                    else
                    {
                        X--;
                    }
                }
            }
            if (keyPress.IsKeyDown(Keys.W))
            {
                for (int i = 0; i < Speed; i++)
                {
                    if (Y <= 0 + height / 2)
                    {
                        return;
                    }
                    else
                    {
                        Y--;
                    }
                }
            }
            if (keyPress.IsKeyDown(Keys.S))
            {
                for (int i = 0; i < Speed; i++)
                {
                    if (Y >= 1080 - height / 2)
                    {
                        return;
                    }
                    else
                    {
                        Y++;
                    }
                }
            }
        }
    }
}