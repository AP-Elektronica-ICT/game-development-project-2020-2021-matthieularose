using System;
using System.Collections.Generic;
using System.IO;
using GameDev_Project;
using GameDevProject.Background;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States
{
    public class MenuState : State
    {
        public List<Component> components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, TextureManager textureManager) : base(game, graphicsDevice, content, textureManager)
        {
            Button lvl1Button = new Button(textureManager.lvl1ButtonTexture)
            {
                Position = new Vector2(300, 200),
            };

            lvl1Button.Click += lvl1Button_Click;

            Button lvl2Button = new Button(textureManager.lvl2ButtonTexture)
            {
                Position = new Vector2(300, 300),
            };

            lvl2Button.Click += lvl2Button_Click;

            components = new List<Component>()
            {
                lvl1Button,
                lvl2Button
            };
        }

        private void lvl1Button_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, textureManager, 1));
        }

        private void lvl2Button_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, textureManager, 2));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Remove sprites if not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }
    }
}
