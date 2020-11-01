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
        private Texture2D chatbox { get; set; }
        private Texture2D chatbox2 { get; set; }
        private Texture2D text { get; set; }
        private Texture2D _texture { get; set; }
        private SpriteBatch spriteBatch;
        private int startX { get; set; }
        private int moveAmount { get; set; }
        private int moveLeft { get; set; }
        private int ticker;
        private int nextX;
        private bool inc;
        public bool chatBox;
        public bool chatBox2;
        KeyboardState oldState;
        public bool textShow;
        public bool haveKnife;

        public Npc(int x, int y, SpriteBatch spriteBatch, GameContent gameContent, int dir, int amount)
        {
            X = x;
            Y = y;
            npc = gameContent.npc;
            chatbox = gameContent.chatbox;
            chatbox2 = gameContent.chatbox2;
            text = gameContent.text;
            width = npc.Width;
            height = npc.Height;
            this.spriteBatch = spriteBatch;
            int direction = dir;
            moveAmount = amount;
            moveLeft = moveAmount;
        }

        public void Draw()
        {
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), hitBox, Color.White);
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), interactionArea, Color.White);
            spriteBatch.Draw(npc, new Vector2(X, Y), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            if (chatBox)
            {
                spriteBatch.Draw(chatbox, new Vector2(700, 900 - height), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            }
            if (chatBox2)
            {
                spriteBatch.Draw(chatbox2, new Vector2(700, 900 - height), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            }
            if (textShow)
            {
                spriteBatch.Draw(text, new Vector2(1700, 100), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            }
        }

        public Rectangle hitBox
        {
            get
            {
                return new Rectangle((int)X-width, (int)Y - height, (int)npc.Width, (int)npc.Height);
            }
        }

        public Rectangle newMove => new Rectangle(nextX - width , Y - height, npc.Width, npc.Height);
        public Rectangle interactionArea => new Rectangle(X - width-75, Y - height-75, npc.Width + 150, npc.Height + 150);

        public void Update(List<Player> players)
        {
            foreach (Player player in players)
            {
                if (this.interactionArea.Intersects(player.newMove))
                {
                    textShow = true;
                    KeyboardState newState = Keyboard.GetState();  // get the newest state

                    // handle the input
                    if (oldState.IsKeyUp(Keys.E) && newState.IsKeyDown(Keys.E))
                    {
                        textShow = false;
                        chatBox = true;
                    }
                    if (oldState.IsKeyUp(Keys.Space) && newState.IsKeyDown(Keys.Space) && chatBox)
                    {
                        chatBox = false;
                        chatBox2 = true;
                        oldState = newState;
                    }
                    if (oldState.IsKeyUp(Keys.Space) && newState.IsKeyDown(Keys.Space) && chatBox2)
                    {
                        chatBox = false;
                        chatBox2 = false;
                        player.knife = true;
                    }
                    oldState = newState;
                }
                else
                {
                    textShow = false;
                    chatBox = false;
                    X = nextX;
                    if (inc)
                    {
                        moveLeft -= 1;
                    }
                    else
                    {
                        ticker++;
                        if (ticker == moveAmount)
                        {
                            moveLeft = moveAmount;
                        }
                    }
                }

            }
        }


        public void Update()
        {
            if (moveLeft > 0)
            {
                ticker = 0;
                nextX = X + 1;
                inc = true;
            }
            if(moveLeft == 0)
            {
                nextX = X - 1;
                inc = false;
            }
        }
    }
}