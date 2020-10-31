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
        private Texture2D _texture { get; set; }
        private SpriteBatch spriteBatch;
        private bool rotated;
        private int midWidth;
        private int midHeight;

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
            midHeight = wall.Height / 2;
            midWidth = wall.Width / 2;
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), hitBox, Color.White);
            spriteBatch.Draw(wall, new Vector2(X, Y), null, Color.White, rotation, new Vector2(midWidth, midHeight), 1.0f, SpriteEffects.None, 0);
        }

        public Rectangle hitBox
        {
            get
            {
                if (rotated)
                {
                    return new Rectangle((int)X - 25, (int)Y - 100, (int)wall.Height, (int)wall.Width);
                }
                else
                {
                    return new Rectangle((int)X - 100, (int)Y - 25, (int)wall.Width, (int)wall.Height);
                }
            }
        }
    }
}