
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace COFinalProject
{
    class Plane : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        SpriteFont hilightFont;

        public Texture2D[] plane = new Texture2D[3];
        Texture2D [] birdTexture = new Texture2D [4];
        Texture2D bulletTexture;
        Texture2D bombTexture;

        SoundEffect shootingSound;
        SoundEffect loseSound;
        
        public int planeState = 0;
        public int counter = 0;
        public int gravity = 5;
        public int planeSpeed = 8;

        public Vector2 planePosition = new Vector2(250,250);
        Vector2 shootPosition;
        Vector2 birdPosition;

        DateTime lastShot = DateTime.Now;
        TimeSpan reloadTime = new TimeSpan(0,0,0,0,100);
        DateTime lastBird = DateTime.Now;
        TimeSpan reloadBird = new TimeSpan(0, 0, 0, 1);
        KeyboardState previousKeys;

        List<Shoot> lasers;
        List<Birds> birds;
        List<Explode> bombs;
        Rectangle planeRec = new Rectangle(100, 100, 150, 150); 
        Rectangle screen = new Rectangle(0, 0, 1300, 850);

        string text = "GAME OVER ";
        string text2 ="\n Press 'esc' to \n return to main \n menu";
        int score = 0;
        
        public void propeller() //plane annimation method
        { 
            if(planeState == 2)
            {
                return;
            }
            counter++;
            if (counter < 4)
            {
                planeState = 0;
            }
            else if (counter < 8)
            {
                planeState = 1;
            }
            else
            {
                counter = 0;
            }
        }
        public Plane(Game game, SpriteBatch spritebatch, Texture2D planeTexture, Texture2D planeTexture2, Texture2D bulletTexture, Texture2D [] birdTexture, 
            SoundEffect shootingSound, SoundEffect loseSound, Texture2D planeDead, SpriteFont spriteFont, SpriteFont hilightFont, 
            Texture2D explosion, Texture2D bombTexture) : base(game)
        {
            this.spriteBatch = spritebatch;
            this.plane[0] = planeTexture;
            this.plane[1] = planeTexture2;
            this.bulletTexture = bulletTexture;
            this.birdTexture = birdTexture;
            this.shootingSound = shootingSound;
            this.loseSound = loseSound;
            this.plane[2] = planeDead;
            this.spriteFont = spriteFont;
            this.hilightFont = hilightFont;
            this.bombTexture = bombTexture;
            lasers = new List<Shoot>();
            birds = new List<Birds>();
            bombs =  new List<Explode>();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(plane[planeState], new Rectangle((int)planePosition.X, (int)planePosition.Y, 200, 200), Color.White);
            foreach(Shoot s in lasers)
            {
                s.Draw();
            }

            foreach (Birds b in birds)
            {
                b.Draw(gameTime);
            }
            foreach(Explode e in bombs)
            {
                e.Draw();
            }
            if (planeState == 2){ spriteBatch.DrawString(spriteFont, text, new Vector2(500, 400), Color.HotPink); }
            if (planeState == 2) { spriteBatch.DrawString(hilightFont, text2, new Vector2(50,50), Color.HotPink); }

            spriteBatch.DrawString(spriteFont, "Score: " + score, new Vector2(1000, 50), Color.HotPink);
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (planeState != 2)
            {
                KeyboardState keyState = Keyboard.GetState();
                planePosition.Y += gravity;
                propeller();

                if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
                {
                    planePosition.X += planeSpeed;
                }
                if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
                {
                    planePosition.X -= planeSpeed;
                }
                if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
                {
                    planePosition.Y -= planeSpeed + gravity;
                }
                if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
                {
                    planePosition.Y += planeSpeed - gravity;
                }

                if (keyState.IsKeyDown(Keys.F) || keyState.IsKeyDown(Keys.Space))
                {

                    if (DateTime.Now - lastShot > reloadTime)
                    {
                        lasers.Add(new Shoot(spriteBatch, bulletTexture, shootPosition));
                        lastShot = DateTime.Now;
                        shootingSound.Play();
                    }

                }
                planeRec.X = (int)planePosition.X;
                planeRec.Y = (int)planePosition.Y;
                //setting the bullet position 
                shootPosition.X = planePosition.X + 125;
                shootPosition.Y = planePosition.Y + 160;
                //birds follow the plane position
                birdPosition.X = Game.GraphicsDevice.Viewport.Width;
                birdPosition.Y = planePosition.Y + 140;

                //shooting the birds 
                for (int i = 0; i < lasers.Count; i++)
                {
                    Shoot s = lasers[i];
                    s.Update();
                    for (int j = 0; j < birds.Count; j++)
                    {
                        Birds b = birds[j];
                        if (b.birdRec.Contains(s.shootPosition))
                        {
                            bombs.Add(new Explode(spriteBatch, bombTexture, b.birdPosition));
                            birds.Remove(b);
                            lasers.Remove(s);
                            score++; //for every bird shot add 1 point to the score
                        }
                    }
                }
                //setting the explosion image for every time a bird is shot
                for (int i = 0; i < bombs.Count; i++)
                {
                    Explode e = bombs[i];
                    if (DateTime.Now - e.exploded > e.explosionAction)
                    {
                        bombs.Remove(e);
                    }
                }
                //reloading birds
                if (DateTime.Now - lastBird > reloadBird)
                {
                    birds.Add(new Birds(spriteBatch, birdTexture, birdPosition));
                    lastBird = DateTime.Now;
                }
                //if a bird and the plane collide with eachother - game over 
                foreach (Birds b in birds)
                {
                    b.Update();

                    if (b.birdPosition.X > Game.GraphicsDevice.Viewport.Width)
                    {
                        birds.Remove(b);
                    }
                    if (planeRec.Contains(b.birdPosition))
                    {
                        planeState = 2;
                        MediaPlayer.Stop();
                        loseSound.Play();
                    }
                }
                //if the plane goes out of screen - game over 
                if (!screen.Contains(planePosition))
                {
                    planeState = 2;
                    MediaPlayer.Stop();
                    loseSound.Play();
                }
                previousKeys = Keyboard.GetState();
            }
        
        }
    }
}
