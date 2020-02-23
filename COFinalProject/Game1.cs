using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using AllInOneMono;
using Microsoft.Xna.Framework.Content;

namespace COFinalProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        
        public StartScene startScene;
        private ActionScene actionScene;
        private HelpScene helpScene;
        private HowToPlayScene howToPlayScene;
        private AboutScene aboutScene;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

             //Content = new ResourceContentManager(this.Services, Resource1.ResourceManager);

            graphics.PreferredBackBufferHeight = 850;
            graphics.PreferredBackBufferWidth = 1300;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

        }

        private void hideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MediaPlayer.Stop();

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            //create other scenes here and add to component list
            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            howToPlayScene = new HowToPlayScene(this);
            this.Components.Add(howToPlayScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;

            KeyboardState ks = Keyboard.GetState();
            
            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    MediaPlayer.Stop();

                    actionScene = new ActionScene(this);
                    this.Components.Add(actionScene);
                    actionScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    howToPlayScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScene.show();
                }
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
                
            }
            
            if (actionScene.Enabled || helpScene.Enabled || howToPlayScene.Enabled || aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
