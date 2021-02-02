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
        /*---GAMEOBJECTS---*/
        Level level;
        Player player;

        /*---CAMERA---*/
        int cameraOffsetX = 150;

        /*---BACKGROUND---*/
        ParallaxBackground background;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, TextureManager textureManager, int lvl) : base(game, graphicsDevice, content, textureManager)
        {
            background = new ParallaxBackground(textureManager.backgroundTextures);
            background.Initialize();

            level = new Level(content, textureManager.tileTexture, lvl);
            level.Initialize();

            player = new Player(new KeyboardInput(), level.tiles);
            player.animationManager = new PlayerAnimationManager(textureManager.idleTextureR, textureManager.idleTextureL, textureManager.runTextureR, textureManager.runTextureL, textureManager.jumpTextureR, textureManager.jumpTextureL);
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

            if (player.dead) game.ChangeState(new MenuState(game, graphicsDevice, content, textureManager));
            if (player.finishedLevel) game.ChangeState(new MenuState(game, graphicsDevice, content, textureManager));
        }
    }
}
