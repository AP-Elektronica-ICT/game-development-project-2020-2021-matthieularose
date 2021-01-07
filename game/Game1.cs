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

        private Texture2D plx1;
        private Texture2D plx2;
        private Texture2D plx3;
        private Texture2D plx4;
        private Texture2D plx5;

        /*---GAMEOBJECTS---*/
        Level level;
        Player player;
        //Tile tile;

        /*---CAMERA---*/
        int cameraOffsetX = 150;
        //int cameraOffsetY = 350;

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
                    if (tile.position.Y > player.position.Y)
                    {
                        player.position = new Vector2(player.position.X, tile.position.Y - 64);
                    }
                    else
                    {
                        player.position = new Vector2(player.position.X, tile.position.Y + 32);
                    }
                }
                else
                {
                    //player.position -= new Vector2(0, -0.01f);
                    player.Fall();
                }
            }

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(sortMode: SpriteSortMode.Texture,
                transformMatrix: Matrix.CreateTranslation(- player.position.X + cameraOffsetX, 0, 0));

            drawBackground(); //-> background.Draw()

            level.Draw(_spriteBatch);

            player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
        private void GetTextures()
        {
            //MGCB Editor doesn't work on latest version of MacOS
            string dir = "/Users/matthieu/School/2EA-Cloud/GameDev/game-development-project-2020-2021-matthieularose/game/Content/";

            //Player
            FileStream fileStream = new FileStream(dir + "sprites/idleRight.png", FileMode.Open);
            idleTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/idleLeft.png", FileMode.Open);
            idleTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/runRight.png", FileMode.Open);
            runTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/runLeft.png", FileMode.Open);
            runTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpRight.png", FileMode.Open);
            jumpTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            //Tilesets
            fileStream = new FileStream(dir + "tilesets/tileset1.png", FileMode.Open);
            tileTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

            //Parallax Backgrounds
            fileStream = new FileStream(dir + "backgrounds/plx-1.png", FileMode.Open);
            plx1 = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream = new FileStream(dir + "backgrounds/plx-2.png", FileMode.Open);
            plx2 = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream = new FileStream(dir + "backgrounds/plx-3.png", FileMode.Open);
            plx3 = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream = new FileStream(dir + "backgrounds/plx-4.png", FileMode.Open);
            plx4 = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream = new FileStream(dir + "backgrounds/plx-5.png", FileMode.Open);
            plx5 = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream.Dispose();
        }

        //Temporary
        public void drawBackground()
        {
            _spriteBatch.Draw(plx1, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(plx2, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(plx3, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(plx4, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(plx5, new Vector2(0, 0), Color.White);
        }
    }
}

/*TODO:
 * 
 * Physics
 * 2de Level
 * Menuscherm
 * Player death -> position.Y < 0
 * Game Over Scherm
 * TextureLoader
 * CollisionDetection Class?
 * JSONParser?
 * Background klasse
 * root dir veranderen
 * Sprite (Devider?)
 * 
 */