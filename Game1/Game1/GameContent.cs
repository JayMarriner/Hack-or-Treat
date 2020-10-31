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
    public class GameContent
    {
        public Texture2D player { get; set; }
        public Texture2D wall { get; set; }
        public Texture2D background { get; set; }

        public GameContent(ContentManager Content)
        {
            //load images
            player = Content.Load<Texture2D>("player");
            wall = Content.Load<Texture2D>("wall");
            background = Content.Load<Texture2D>("background");
        }
    }
}