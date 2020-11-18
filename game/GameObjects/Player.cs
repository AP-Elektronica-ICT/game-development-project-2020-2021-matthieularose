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

        SpriteAnimation idleAnimation;

        public Player(Texture2D idle_texture)
        {
            idleTexture = idle_texture;
            idleAnimation = new SpriteAnimation(95, 102, 12);
        }

        public void Update(GameTime gameTime)
        {
            idleAnimation.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (idleTexture != null)spriteBatch.Draw(idleTexture, new Vector2(10, 10), idleAnimation.currentFrame.sourceRectangle, Color.White);
        }
    }
}
