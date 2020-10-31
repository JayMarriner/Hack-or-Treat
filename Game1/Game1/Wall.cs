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
        private float rotation { get; set; } //Rotation
        private Texture2D wall { get; set; } //Wall image
        private SpriteBatch spriteBatch;

        public Wall(float x, float y, SpriteBatch spriteBatch, GameContent gameContent, bool vert)
        {
            X = x;
            Y = y;
            wall = gameContent.wall;
            this.spriteBatch = spriteBatch;
            if (vert)
            {
                rotation = 2.00f;
                rotation = (float)Math.PI / rotation; 
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
    }
}