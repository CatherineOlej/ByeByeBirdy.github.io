using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COFinalProject
{
    public class Birds
    {
        SpriteBatch spriteBatch;
        Texture2D [] birdTexture = new Texture2D [4];
        public Vector2 birdPosition;
        public Rectangle birdRec = new Rectangle(70, 70, 70, 70);
        const float birdSpeed = 5;

        public Birds(SpriteBatch spriteBatch, Texture2D [] birdTexture, Vector2 birdPosition)
        {
            this.spriteBatch = spriteBatch;
            this.birdTexture = birdTexture;
            this.birdPosition = birdPosition;
        }
        public void Update()
        {
            birdPosition.X -= birdSpeed;
            birdRec.X = (int)birdPosition.X;
            birdRec.Y = (int)birdPosition.Y;
        }

        public void Draw(GameTime birdTime)
        {
            Texture2D currentBird = birdTexture[ (int)(birdTime.TotalGameTime.TotalMilliseconds/100 % 4)];

            spriteBatch.Draw(currentBird, new Rectangle(birdPosition.ToPoint(), new Point(70, 70)), Color.White);
        }
    }
}
