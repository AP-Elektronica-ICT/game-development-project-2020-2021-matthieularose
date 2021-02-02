using System;
using GameDev_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States
{
    public abstract class State
    {
        protected Game1 game;
        protected GraphicsDevice graphicsDevice;
        protected ContentManager content;

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            content = contentManager;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void PostUpdate(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
