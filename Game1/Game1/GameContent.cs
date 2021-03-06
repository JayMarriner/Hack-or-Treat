﻿using System;
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
        public Texture2D playerLeft { get; set; }
        public Texture2D playerDown { get; set; }
        public Texture2D playerUp { get; set; }
        public Texture2D npc { get; set; }
        public Texture2D chatbox { get; set; }
        public Texture2D chatbox2 { get; set; }
        public Texture2D text { get; set; }
        public Texture2D weapon { get; set; }
        public Texture2D knife { get; set; }
        public Texture2D enemy { get; set; }

        public GameContent(ContentManager Content)
        {
            //load images
            player = Content.Load<Texture2D>("player");
            wall = Content.Load<Texture2D>("wall");
            background = Content.Load<Texture2D>("background");
            playerLeft = Content.Load<Texture2D>("playerLeft");
            playerDown = Content.Load<Texture2D>("playerDown");
            playerUp = Content.Load<Texture2D>("playerUp");
            npc = Content.Load<Texture2D>("npc");
            chatbox = Content.Load<Texture2D>("chatBox");
            chatbox2 = Content.Load<Texture2D>("chatBox2");
            text = Content.Load<Texture2D>("talk");
            weapon = Content.Load<Texture2D>("weapon");
            knife = Content.Load<Texture2D>("knife");
            enemy = Content.Load<Texture2D>("enemy");
        }
    }
}