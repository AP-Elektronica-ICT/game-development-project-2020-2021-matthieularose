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
        //ParallaxBackground background;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            string dir = "/Users/matthieu/School/2EA-Cloud/GameDev/game-development-project-2020-2021-matthieularose/game/Content/";
            FileStream fileStream = new FileStream(dir + "controls/lvl1.png", FileMode.Open);
            Texture2D lvl1ButtonTexture = Texture2D.FromStream(graphicsDevice, fileStream);
            fileStream = new FileStream(dir + "controls/lvl2.png", FileMode.Open);
            Texture2D lvl2ButtonTexture = Texture2D.FromStream(graphicsDevice, fileStream);
            //fileStream = new FileStream(dir + "Fonts/Font", FileMode.Open);
            //SpriteFont buttonFont = SpriteFont.FromStream(graphicsDevice, fileStream);
            //SpriteFont buttonFont = 

            //background = new ParallaxBackground(backgroundTextures);
            //background.Initialize();

            Button lvl1Button = new Button(lvl1ButtonTexture, null)
            {
                Position = new Vector2(300, 200),
                Text = "",
            };

            lvl1Button.Click += lvl1Button_Click;

            Button lvl2Button = new Button(lvl2ButtonTexture, null)
            {
                Position = new Vector2(300, 300),
                Text = ""
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
            game.ChangeState(new GameState(game, graphicsDevice, content, 1));
        }

        private void lvl2Button_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content, 2));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //background.Draw(spriteBatch);

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
