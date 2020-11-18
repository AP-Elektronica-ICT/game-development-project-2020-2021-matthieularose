using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;

namespace GameDevProject.GameObjects
{
    public class Player : IGameObject
    {
        Texture2D idleTexture;
        Texture2D runTexture;

        SpriteAnimation idleAnimation;
        SpriteAnimation runAnimation;

        public Player(Texture2D idle, Texture2D run)
        {
            idleTexture = idle;
            runTexture = run;

            idleAnimation = new SpriteAnimation(95, 102, 12);
            runAnimation = new SpriteAnimation(105, 66, 8);
        }

        public void Update(GameTime gameTime)
        {
            runAnimation.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (runTexture != null)spriteBatch.Draw(runTexture, new Vector2(10, 10), runAnimation.currentFrame.sourceRectangle, Color.White);
        }
    }
}
