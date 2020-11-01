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
    public class Npc
    {
        public int X { get; set; } 
        public int Y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private Texture2D npc { get; set; }
        private Texture2D _texture { get; set; }
        private SpriteBatch spriteBatch;

        public Npc(int x, int y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            X = x;
            Y = y;
            npc = gameContent.npc;
            width = npc.Width;
            height = npc.Height;
            this.spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), hitBox, Color.White);
            spriteBatch.Draw(npc, new Vector2(X, Y), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
        }

        public Rectangle hitBox
        {
            get
            {
                return new Rectangle((int)X-width, (int)Y - height, (int)npc.Width, (int)npc.Height);
            }
        }
    }
}