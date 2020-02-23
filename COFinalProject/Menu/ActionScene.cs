using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOneMono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace COFinalProject
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;

        SpriteFont Font, hilightFont;
        Background bg;
        Plane player;
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            bg = new Background(0,850, g.Content.Load<Texture2D>("BG"));
            Font = g.Content.Load<SpriteFont>("Fonts/regularFont");
            hilightFont = g.Content.Load<SpriteFont>("Fonts/hilightFont");

            SoundEffect shootingSound = g.Content.Load<SoundEffect>("Laser2");
            SoundEffect loseSound = g.Content.Load<SoundEffect>("lose sound 1_0");

            Song backMusic = g.Content.Load<Song>("Battle in the winter");
            backMusic = g.Content.Load<Song>("Battle in the winter");
            MediaPlayer.Play(backMusic);

            // from inititalize
            Texture2D[] textureArray = new Texture2D[4];
            textureArray[0] = g.Content.Load<Texture2D>("spriteBird");
            textureArray[1] = g.Content.Load<Texture2D>("spriteBird2");
            textureArray[2] = g.Content.Load<Texture2D>("spriteBird3");
            textureArray[3] = g.Content.Load<Texture2D>("spriteBird4");

            player = new Plane(g, spriteBatch, g.Content.Load<Texture2D>("Fly"), 
                g.Content.Load<Texture2D>("Fly2"), 
                g.Content.Load<Texture2D>("Bullet"),
                textureArray, g.Content.Load<SoundEffect>("Laser2"), 
                g.Content.Load<SoundEffect>("lose sound 1_0"), 
                g.Content.Load<Texture2D>("Dead"), Font, hilightFont,
                g.Content.Load<Texture2D>("StartExplosion"), 
                g.Content.Load<Texture2D>("StartExplosion"));
        }
        public override void Update(GameTime gameTime)
        {
            bg.move(); //call method to scroll background
            player.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            bg.Draw(spriteBatch, graphics); //draw background
            player.Draw(gameTime); // draw plane
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
