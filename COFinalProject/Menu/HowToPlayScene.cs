using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOneMono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COFinalProject
{
    public class HowToPlayScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D playTex;
        Background bg;
        GraphicsDeviceManager graphics;
        public HowToPlayScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            playTex = g.Content.Load<Texture2D>("Images/HowToPlay");
            bg = new Background(0, 850, g.Content.Load<Texture2D>("BG"));
        }

        public override void Update(GameTime gameTime)
        {
            bg.move();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            bg.Draw(spriteBatch, graphics);
            spriteBatch.Draw(playTex, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
