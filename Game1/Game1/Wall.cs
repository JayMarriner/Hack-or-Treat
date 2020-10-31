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
        public float X { get; set; } //Wall x coord
        public float Y { get; set; } //Wall y coord
        public float wallWidth { get; set; } //Wall width
        public float wallHeight { get; set; } //Wall height
        private float rotation { get; set; } //Rotation
        private Texture2D wall { get; set; } //Wall image
        private SpriteBatch spriteBatch;

        public Wall(float x, float y, float width, float height, SpriteBatch spriteBatch, GameContent gameContent, bool vert)
        {
            X = x;
            Y = y;
            width = wallWidth;
            height = wallHeight;
            wall = gameContent.wall;
            this.spriteBatch = spriteBatch;
            if (vert)
            {
                rotation = 45;
            }
            else
            {
                rotation = 0;
            }
        }

        public void Draw()
        {
            float Xcentre = wallHeight / 2;
            float Ycentre = wallWidth / 2;
            spriteBatch.Draw(wall, new Vector2(X, Y), null, Color.White, rotation, new Vector2(Xcentre, Ycentre), 1.0f, SpriteEffects.None, 0);
        }
    }
}