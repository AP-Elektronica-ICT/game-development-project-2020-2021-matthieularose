using System;
using GameDev_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States
{
    //De GameStates heb ik met behulp van deze video gemaakt: "https://www.youtube.com/watch?v=76Mz7ClJLoE&ab_channel=Oyyou"
    public abstract class State
    {
        protected Game1 game;
        protected GraphicsDevice graphicsDevice;
        protected ContentManager content;
        protected TextureManager textureManager;

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager, TextureManager textureManager)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            content = contentManager;
            this.textureManager = textureManager;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void PostUpdate(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
