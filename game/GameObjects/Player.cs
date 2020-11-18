using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;

namespace GameDevProject.GameObjects
{
    public class Player : IGameObject, ITransform
    {
        public Vector2 position { get; set; }

        Texture2D texture;
        Texture2D idleTexture;
        Texture2D runTexture;

        SpriteAnimation animation;
        SpriteAnimation idleAnimation;
        SpriteAnimation runAnimation;

        IReadInput inputReader;

        public Player(Texture2D idle, Texture2D run, IReadInput reader)
        {
            idleTexture = idle;
            runTexture = run;

            idleAnimation = new SpriteAnimation(95, 102, 12);
            runAnimation = new SpriteAnimation(105, 66, 8);

            texture = idleTexture;
            animation = idleAnimation;

            inputReader = reader;

            position = new Vector2(20, 350);
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            direction *= 4;
            position += direction;

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, position, animation.currentFrame.sourceRectangle, Color.White);
        }
    }
}
