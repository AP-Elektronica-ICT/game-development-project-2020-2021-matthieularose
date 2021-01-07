using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GameDevProject.Animation;
using GameDevProject.Collision;
using GameDevProject.GameObjects;
using GameDevProject.GameObjects.World;
using GameDevProject.Input;
using GameDevProject.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        CollisionManager collisionManager;

        /*---TEXTURES---*/
        private Texture2D idleTextureR;
        private Texture2D idleTextureL;
        private Texture2D runTextureR;
        private Texture2D runTextureL;
        private Texture2D jumpTextureR;
        private Texture2D jumpTextureL;

        private Texture2D tileTexture;

        /*---GAMEOBJECTS---*/
        Level level;
        Player player;
        //Tile tile;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GetTextures();
            
            level = new Level(Content, tileTexture);
            level.Create();

            player = new Player(idleTextureR, idleTextureL, runTextureR, runTextureL, jumpTextureR, jumpTextureL, new KeyboardInput());
            player.animationManager = new PlayerAnimationManager(idleTextureR, idleTextureL, runTextureR, runTextureL, jumpTextureR, jumpTextureL);

            collisionManager = new CollisionManager();

            //tile = new Tile(tileTexture, new Vector2(0, 384));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Tile tile in level.tiles)
            {
                if (collisionManager.CollisionDetection(player.CollisionRectangle, tile.CollisionRectangle))
                {
                    Debug.WriteLine("a");
                }
                else
                {
                    //FALL
                    
                }
            }

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            level.Draw(_spriteBatch);

            player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
        private void GetTextures()
        {
            //MGCB Editor doesn't work on latest version of MacOS
            string dir = "/Users/matthieu/School/2EA-Cloud/GameDev/game-development-project-2020-2021-matthieularose/game/Content/sprites/";

            FileStream fileStream = new FileStream(dir + "idleRight.png", FileMode.Open);
            idleTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "idleLeft.png", FileMode.Open);
            idleTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "runRight.png", FileMode.Open);
            runTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "runLeft.png", FileMode.Open);
            runTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "jumpRight.png", FileMode.Open);
            jumpTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "tileSheet.png", FileMode.Open);
            tileTexture = Texture2D.FromStream(GraphicsDevice, fileStream);


            fileStream.Dispose();
        }
    }
}
