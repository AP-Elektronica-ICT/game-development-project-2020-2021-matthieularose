using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;
using GameDevProject.Commands;

namespace GameDevProject.GameObjects
{
    public class Player : IGameObject, ITransform
    {
        public Vector2 position { get; set; }

        Texture2D texture;
        Texture2D idleTexture;
        Texture2D runTexture;
        Texture2D runTextureL;

        SpriteAnimation animation;
        SpriteAnimation idleAnimation;
        SpriteAnimation runAnimation;
        SpriteAnimation runAnimationL;

        private IReadInput inputReader;
        private IMoveCommand runCommand = new RunCommand();
        private IMoveCommand jumpCommand = new JumpCommand();


        public Player(Texture2D idle, Texture2D run, Texture2D runL, IReadInput reader)
        {
            idleTexture = idle;
            runTexture = run;
            runTextureL = runL;

            idleAnimation = new SpriteAnimation(95, 102, 12);
            runAnimation = new SpriteAnimation(105, 66, 8);
            runAnimationL = new SpriteAnimation(105, 66, 8);

            texture = idleTexture;
            animation = idleAnimation;

            inputReader = reader;

            position = new Vector2(20, 350);
        }

        public void Update(GameTime gameTime)
        {
            //TODO: MoveManager
            var direction = inputReader.ReadInput();

            if (direction.X != 0) runCommand.Execute(this, direction);
            if (direction.Y != 0) jumpCommand.Execute(this, direction);

            //TODO: AnimationManager + JumpAnimation
            if (direction.X > 0)
            {
                texture = runTexture;
                animation = runAnimation;
            }
            else if (direction.X < 0)
            {
                texture = runTextureL;
                animation = runAnimationL;
            }
            else
            {
                texture = idleTexture;
                animation = idleAnimation;
            }

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, position, animation.currentFrame.sourceRectangle, Color.White);
        }
    }
}
