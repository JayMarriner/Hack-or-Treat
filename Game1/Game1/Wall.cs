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
    public class Wall
    {
        public int X { get; set; } //Wall x coord
        public int Y { get; set; } //Wall y coord
        public float width { get; set; }
        public float height { get; set; }
        private float rotation { get; set; } //Rotation
        private Texture2D wall { get; set; } //Wall image
        private SpriteBatch spriteBatch;
        private bool rotated;

        public Wall(int x, int y, SpriteBatch spriteBatch, GameContent gameContent, bool vert)
        {
            X = x;
            Y = y;
            wall = gameContent.wall;
            width = wall.Width;
            height = wall.Height;
            this.spriteBatch = spriteBatch;
            if (vert)
            {
                rotation = 2.00f;
                rotation = (float)Math.PI / rotation;
                rotated = true;
            }
            else
            {
                rotation = 1.00f;
                rotation = (float)Math.PI / rotation;
            }
        }

        public void Draw()
        {
            spriteBatch.Draw(wall, new Vector2(X, Y), null, Color.White, rotation, new Vector2(wall.Width/2, wall.Height/2), 1.0f, SpriteEffects.None, 0);
        }

        public Rectangle hitBox
        {
            get
            {
                if (rotated)
                {
                    return new Rectangle((int)X, (int)Y, (int)height, (int)width);
                }
                else
                {
                    return new Rectangle((int)X, (int)Y, (int)width, (int)height);
                }
            }
        }
    }
}