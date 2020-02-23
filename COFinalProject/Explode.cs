using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFinalProject
{
    class Explode
    {
        SpriteBatch spriteBatch;
        public Texture2D bombTexture;
        public Vector2 bomb;
        public DateTime exploded = DateTime.Now;
        public TimeSpan explosionAction = new TimeSpan(0, 0, 1);

        public Explode(SpriteBatch spriteBatch, Texture2D bombTexture, Vector2 bomb)
        {
            this.spriteBatch = spriteBatch;
            this.bombTexture = bombTexture;
            this.bomb = bomb;
        }
        public void Draw()
        {
            spriteBatch.Draw(bombTexture, new Rectangle(bomb.ToPoint(), new Point(70,70)), Color.White);
        }
    }
}
