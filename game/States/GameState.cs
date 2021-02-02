using System;
using System.Collections.Generic;
using System.IO;
using GameDev_Project;
using GameDevProject.Animation;
using GameDevProject.Background;
using GameDevProject.GameObjects;
using GameDevProject.Input;
using GameDevProject.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States
{
    public class GameState : State
    {
        private GraphicsDevice GraphicsDevice;
        private SpriteBatch _spriteBatch;

        /*---TEXTURES---*/
        private Texture2D idleTextureR;
        private Texture2D idleTextureL;
        private Texture2D runTextureR;
        private Texture2D runTextureL;
        private Texture2D jumpTextureR;
        private Texture2D jumpTextureL;

        private Texture2D tileTexture;

        private List<Texture2D> backgroundTextures = new List<Texture2D>();

        /*---GAMEOBJECTS---*/
        Level level;
        Player player;

        /*---CAMERA---*/
        int cameraOffsetX = 150;
        //int cameraOffsetY = 350;

        /*---BACKGROUND---*/
        ParallaxBackground background;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int lvl) : base(game, graphicsDevice, content)
        {
            GraphicsDevice = graphicsDevice;

            GetTextures();

            background = new ParallaxBackground(backgroundTextures);
            background.Initialize();

            level = new Level(content, tileTexture);
            level.Initialize();

            player = new Player(new KeyboardInput(), level.tiles);
            player.animationManager = new PlayerAnimationManager(idleTextureR, idleTextureL, runTextureR, runTextureL, jumpTextureR, jumpTextureL);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Matrix.CreateTranslation(-player.Position.X + cameraOffsetX, 0, 0));

            background.Draw(spriteBatch);

            player.Draw(spriteBatch);

            level.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Remove
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            if (player.dead) game.ChangeState(new MenuState(game, graphicsDevice, content));
            if (player.finishedLevel) game.ChangeState(new MenuState(game, graphicsDevice, content));
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
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-2.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-3.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-4.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-5.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream.Dispose();
        }
    }
}
