using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOneMono;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace COFinalProject
{
    public class StartScene : GameScene
    {
        Background bg;
        SpriteFont text;
        private GraphicsDeviceManager graphics;
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        string[] menuItems = { "Start Game",
                                    "Help",
                                "How To Play",
                                    "About",
                                "Quit"};
        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g.spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("Fonts/hilightFont");
            text = g.Content.Load<SpriteFont>("Fonts/regularFont");
            bg = new Background(0, 850, g.Content.Load<Texture2D>("BG"));

            Menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(Menu);
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
            spriteBatch.DrawString(text, "Bye Bye Birdy", new Vector2(500, 200), Color.HotPink);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
