using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Draw = System.Drawing;

namespace Game1
{
    public class Player
    {
        public int X { get; set; } //Players x coord
        public int Y { get; set; } //Players y coord
        public int width { get; set; } //Players width
        public int height { get; set; } //Players height
        public float screenWidth { get; set; } //Width of screen
        public float screenHeight { get; set; } //Height of screen
        private Texture2D playerRight { get; set; } //Player image
        public int Speed { get; set; }
        private SpriteBatch spriteBatch;
        private int newPosX;
        private int newPosY;
        private bool moving;
        private Texture2D playerLeft { get; set; }
        private Texture2D playerDown { get; set; }
        private Texture2D playerUp { get; set; }
        private int direction = 4;
        private bool objHit;
        public bool knife { get; set; }
        private Texture2D weapon { get; set; }
        public bool dead;
        private SpriteBatch knifeSpriteBatch;
        private Texture2D knifeTex { get; set; }
        private List<Knife> knives;
        GameContent gameCon;
        KeyboardState oldState;
        bool knifeThrown;

        public Player(int x, int y, float screenW, float screenH, SpriteBatch spriteBatch, GameContent gameContent, int speed)
        {
            X = x;
            Y = y;
            gameCon = gameContent;
            playerRight = gameContent.player;
            playerLeft = gameContent.playerLeft;
            playerUp = gameContent.playerUp;
            playerDown = gameContent.playerDown;
            weapon = gameContent.weapon;
            width = playerRight.Width;
            height = playerRight.Height;
            this.spriteBatch = spriteBatch;
            screenWidth = screenWidth + (playerRight.Width / 2);
            screenHeight = screenHeight + (playerRight.Height / 2);
            Speed = speed;
            knifeTex = gameContent.knife;
            knifeSpriteBatch = spriteBatch;
            knives = new List<Knife>();
        }

        public void Draw()
        {
            knives.ForEach(x => x.Draw());
            if (dead)
            {
                return;
            }
            float Xcentre = height / 2;
            float Ycentre = width / 2;
            if (direction == 1)
            {
                spriteBatch.Draw(playerUp, new Vector2(X, Y), null, Color.White, 0, new Vector2(Xcentre, Ycentre), 1.0f, SpriteEffects.None, 0);
            }
            if (direction == 2)
            {
                spriteBatch.Draw(playerDown, new Vector2(X, Y), null, Color.White, 0, new Vector2(Xcentre, Ycentre), 1.0f, SpriteEffects.None, 0);
            }
            if (direction == 3)
            {
                spriteBatch.Draw(playerLeft, new Vector2(X, Y), null, Color.White, 0, new Vector2(Xcentre, Ycentre), 1.0f, SpriteEffects.None, 0);
            }
            if (direction == 4)
            {
                spriteBatch.Draw(playerRight, new Vector2(X, Y), null, Color.White, 0, new Vector2(Xcentre, Ycentre), 1.0f, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), hitBox, Color.White);
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), newMove, Color.White);
            if (knife)
            {
                spriteBatch.Draw(weapon, new Vector2(1700, 1050), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            }
        }

        public Rectangle hitBox => new Rectangle(X - width/2, Y - height/2, width, height);
        public Rectangle newMove => new Rectangle(newPosX - width/2, newPosY - height/2, width, height);

        public void Update(List<Wall> walls)
        {
             foreach(Wall wall in walls)
            {
                if (this.newMove.Intersects(wall.hitBox))
                {
                    return;
                }
            }
            if (moving)
            {
                if(newPosX > 1920 || newPosX < 0 + width || newPosY < 0 || newPosY > 1080 - height || objHit)
                {
                    return;
                }
                X = newPosX;
                Y = newPosY;
                moving = false;
            }
        }

        public void Update(List<Npc> npcs)
        {
            foreach (Npc npc in npcs)
            {
                if (this.newMove.Intersects(npc.hitBox))
                {
                    objHit = true;
                }
                else
                {
                    objHit = false;
                }
            }
        }

        public void attackUpdate(List<Enemy> enemies)
        {
            knives.ForEach(x => x.knifeUpdatePlayer(enemies));
            foreach (Enemy enemy in enemies)
            {
                if (this.newMove.Intersects(enemy.newMove))
                {
                    return;
                }
                else
                {
                    KeyboardState newState = Keyboard.GetState();  // get the newest state

                    // handle the input
                    if (oldState.IsKeyUp(Keys.L) && newState.IsKeyDown(Keys.L))
                    {
                        if (knife)
                        {
                            knives.Add(new Knife(X - width / 2, Y + 10, knifeSpriteBatch, gameCon, 8, direction));
                        }
                        knifeThrown = true;
                    }
                }

            }
        }

        public void movementUpdate()
        {
            if (dead)
            {
                return;
            }
            KeyboardState keyPress = Keyboard.GetState();
            if (keyPress.IsKeyDown(Keys.W))
            {
                newPosY = Y - Speed;
                newPosX = X;
                moving = true;
                direction = 1;
            }
            if (keyPress.IsKeyDown(Keys.S))
            {
                newPosY = Y + Speed;
                newPosX = X;
                moving = true;
                direction = 2;
            }
            if (keyPress.IsKeyDown(Keys.A))
            {
                newPosY = Y;
                newPosX = X - Speed;
                moving = true;
                direction = 3;
            }
            if (keyPress.IsKeyDown(Keys.D))
            {
                newPosY = Y;
                newPosX = X + Speed;
                moving = true;
                direction = 4;
            }
        }
    }
}

