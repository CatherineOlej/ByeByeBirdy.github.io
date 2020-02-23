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
    class Background 
    {
        public int backgroundPosition1;
        public int backgroundPosition2;
        public Texture2D backgroundTexture;
        //Height = 850;
        //Width = 1300;
        public Background(int backgroundPosition1, int backgroundPosition2, Texture2D backgroundTexture)
        {
            this.backgroundPosition1 = backgroundPosition1;
            this.backgroundPosition2 = backgroundPosition2;
            this.backgroundTexture = backgroundTexture;
        }
        public void move()
        {
            backgroundPosition1--;
            backgroundPosition2--;
            if (backgroundPosition2 <= 0)
            {
                backgroundPosition1 = 0;
                backgroundPosition2 = 1300;
            }
        }
        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(backgroundPosition1, 0, 1300, 850), Color.White);
            spriteBatch.Draw(backgroundTexture, new Rectangle(backgroundPosition2 - 2, 0, 1300, 850), Color.White);
        }
    }
}
