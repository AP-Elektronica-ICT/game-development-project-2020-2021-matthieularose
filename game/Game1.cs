using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GameDevProject;
using GameDevProject.Animation;
using GameDevProject.Background;
using GameDevProject.GameObjects;
using GameDevProject.GameObjects.World;
using GameDevProject.Input;
using GameDevProject.LevelDesign;
using GameDevProject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * Om de textures te laden, moet u de directory path van de content nog even aanpassen (in de TextureManager klasse).
 * Ik moest dit zo doen, omdat de MGCB Editor niet werkt voor de laatste versie van MacOS.
 */

namespace GameDev_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private State currentState;
        private State nextState;

        TextureManager textureManager;

        public void ChangeState(State state)
        {
            nextState = state;
        }

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

            textureManager = new TextureManager(GraphicsDevice);

            currentState = new MenuState(this, _graphics.GraphicsDevice, Content, textureManager);
        }

        protected override void Update(GameTime gameTime)
        {
            if(nextState != null)
            {
                currentState = nextState;
                nextState = null;
            }

            currentState.Update(gameTime);

            currentState.PostUpdate(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            currentState.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}

/*TODO:
 * 
 * JSONParser + levels in JSON files opslaan
 * Parallax
 * Sound
 * 
 */