using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1
{

    public class Background
    {
        private SpriteBatch spriteBatch;
        private Texture2D background { get; set; }

        public Background(int x, int y, int height, int width, SpriteBatch spriteBatch, GameContent gameContent)
        {
            height = 1920;
            width = 1080;
            this.spriteBatch = spriteBatch;
            background = gameContent.background;
        }

        public void Draw()
        {
            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }
    }
}