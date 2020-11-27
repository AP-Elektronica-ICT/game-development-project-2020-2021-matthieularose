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
        SpriteAnimation animation;

        public IAnimationManager animationManager;
        private IReadInput inputReader;
        private IMoveCommand runCommand = new RunCommand();
        private IMoveCommand jumpCommand = new JumpCommand();


        public Player(Texture2D idleR, Texture2D idleL, Texture2D runR, Texture2D runL, Texture2D jumpR, Texture2D jumpL, IReadInput reader)
        {
            //animationManager = new PlayerAnimationManager(idleR, idleL, runR, runL, jumpR, jumpL);

            inputReader = reader;

            position = new Vector2(20, 350);
        }

        public void Update(GameTime gameTime)
        {
            //TODO: MoveManager?
            var direction = inputReader.ReadInput();

            if (direction.X != 0) runCommand.Execute(this, direction);
            if (direction.Y != 0) jumpCommand.Execute(this, direction);


            animationManager.Update(direction);
            texture = animationManager.texture;
            animation = animationManager.animation;

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, position, animation.currentFrame.sourceRectangle, Color.White);
        }
    }
}
