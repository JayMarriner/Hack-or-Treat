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
    public class Knife
    {
        int X;
        int Y;
        Texture2D knife;
        int width;
        int height;
        private SpriteBatch spriteBatch;
        int Speed;
        int newX;
        int newY;
        bool knifeHit;
        int dir;

        public Knife(int x, int y, SpriteBatch spriteBatch, GameContent gameContent, int speed, int direction)
        {
            dir = direction;
            X = x;
            Y = y;
            knife = gameContent.knife;
            width = knife.Width;
            height = knife.Height;
            this.spriteBatch = spriteBatch;
            Speed = speed;
        }

        public void Draw()
        {
            spriteBatch.Draw(knife, new Vector2(X, Y), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), hitBox, Color.White);
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), newMove, Color.White);
        }

        public void enemyUpdate()
        {
            Y += Speed;
        }

        public void knifeUpdate(List <Player> players)
        {
            foreach(Player player in players)
            {
                if (this.newMove.Intersects(player.hitBox))
                {
                    player.dead = true;
                }
            }
        }

        public void knifeUpdatePlayer(List<Enemy> enemies)
        {
            if(dir == 1)
            {
                Y-= Speed;
            }
            if (dir == 2)
            {
                Y+= Speed;
            }
            if (dir == 3)
            {
                X-= Speed;
            }
            if (dir == 4)
            {
                X+= Speed;
            }
            foreach (Enemy enemy in enemies)
            {
                if (this.newMove.Intersects(enemy.hitBox))
                {
                    enemy.dead = true;
                }
            }
        }

        public Rectangle hitBox => new Rectangle(X-width, Y-height, width, height);
        public Rectangle newMove => new Rectangle(X-width, Y-height, width, height);

    }
}