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
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpTex;
        Background bg;
        GraphicsDeviceManager graphics;
        public HelpScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            helpTex = g.Content.Load<Texture2D>("Images/helpImage");
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
            spriteBatch.Draw(helpTex, Vector2.Zero, Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
