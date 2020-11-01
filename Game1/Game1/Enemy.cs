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
    public class Enemy
    {
        private SpriteBatch spriteBatch;
        Texture2D enemy;
        int X;
        int Y;
        int width;
        int height;
        int nextX;
        public int moveLeft;
        int ticker;
        int moveAmount;
        public int throwKnife = 0;
        private SpriteBatch knifeSpriteBatch;
        private Texture2D knife { get; set; }
        private List<Knife> knives;
        GameContent gameCon;
        public bool dead;

        public Enemy(int x, int y, SpriteBatch spriteBatch, GameContent gameContent, int amount)
        {
            X = x;
            Y = y;
            gameCon = gameContent;
            enemy = gameCon.enemy;
            width = enemy.Width;
            height = enemy.Height;
            this.spriteBatch = spriteBatch;
            knifeSpriteBatch = spriteBatch;
            moveAmount = amount;
            moveLeft = amount;
            knives = new List<Knife>();
            knife = gameContent.knife;
        }

        public void Draw()
        {
            if (dead)
            {
                return;
            }
            spriteBatch.Draw(enemy, new Vector2(X, Y), null, Color.White, 0, new Vector2(width, height), 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(Game1.BlankTexture(spriteBatch), hitBox, Color.White);
            knives.ForEach(x => x.Draw());
        }

        public Rectangle hitBox
        {
            get
            {
                return new Rectangle((int)X - width, (int)Y - height, (int)enemy.Width, (int)enemy.Height);
            }
        }

        public Rectangle newMove => new Rectangle(nextX - width , Y - height, enemy.Width, enemy.Height);

        public void Update()
        {
            if (dead)
            {
                return;
            }
            knives.ForEach(x => x.enemyUpdate());
            if (moveLeft > 0)
            {
                nextX = X + 1;
                moveLeft--;
            }
            if (moveLeft == 0)
            {
                nextX = X - 1;
                ticker++;
            }
        }

        public void Update(List<Player> players)
        {
            knives.ForEach(x => x.knifeUpdate(players));
            foreach (Player player in players)
            {
                if (this.newMove.Intersects(player.newMove))
                {
                    return;
                }
                else
                {
                    X = nextX;
                    if (ticker == moveAmount)
                    {
                        moveLeft = moveAmount;
                        ticker = 0;
                        throwKnife = 1;
                        knives.Add(new Knife(X-width/2, Y+10, knifeSpriteBatch, gameCon, 8, 2));
                    }
                }

            }
        }
    }
}