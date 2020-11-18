using System.Diagnostics;
using System.IO;
using GameDevProject.GameObjects;
using GameDevProject.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Player
        private Texture2D idleTexture;
        private Texture2D runTexture;
        Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadLevel();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
        private void LoadLevel()
        {
            //Load Textures, MGCB Editor doesn't work on latest version of MacOS
            string dir = "/Users/matthieu/School/2EA-Cloud/GameDev/game-development-project-2020-2021-matthieularose/game/Content/sprites/";

            FileStream fileStream = new FileStream(dir + "idle.png", FileMode.Open);
            idleTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "run.png", FileMode.Open);
            runTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream.Dispose();

            player = new Player(idleTexture, runTexture, new KeyboardInput());
        }
    }
}
