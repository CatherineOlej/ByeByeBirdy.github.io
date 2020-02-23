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
    class Shoot 
    {
        SpriteBatch spriteBatch;
        Texture2D bulletTexture;
        public Vector2 shootPosition;
        const float laserSpeed = 20;
        
        public Shoot(SpriteBatch spriteBatch, Texture2D bulletTexture, Vector2 shootPosition)
        {
            this.spriteBatch = spriteBatch;
            this.bulletTexture = bulletTexture;
            this.shootPosition = shootPosition;
        }
        public void Update()
        {
            shootPosition.X += laserSpeed; 
        }

        public void Draw()
        {
            Point realCenter = new Point((int)shootPosition.X - 25, (int)shootPosition.Y - 25);
            spriteBatch.Draw(bulletTexture, new Rectangle(shootPosition.ToPoint(), new Point(50, 50)), Color.White);
        }
        
    }         
}


