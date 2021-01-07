using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;
using GameDevProject.Commands;
using GameDevProject.Collision;

namespace GameDevProject.GameObjects
{
    public class Player : IGameObject, ITransform, ICollision
    {
        public Vector2 position { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        Texture2D texture;
        SpriteAnimation animation;

        public IAnimationManager animationManager;
        private IReadInput inputReader;
        private IMoveCommand runCommand = new RunCommand();
        private IMoveCommand jumpCommand = new JumpCommand();

        public Collider collider;

        public Player(Texture2D idleR, Texture2D idleL, Texture2D runR, Texture2D runL, Texture2D jumpR, Texture2D jumpL, IReadInput reader)
        {
            //animationManager = new PlayerAnimationManager(idleR, idleL, runR, runL, jumpR, jumpL);

            inputReader = reader;

            position = new Vector2(20, 200);

            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 64);

            collider = new Collider(this);
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();

            if (direction.X != 0) runCommand.Execute(this, direction);
            if (direction.Y != 0) jumpCommand.Execute(this, direction);

            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 64); //Mischien andere manier dan telkens nieuwe Rectangle?

            animationManager.Update(direction);
            texture = animationManager.texture;
            animation = animationManager.animation;

            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, position, animation.currentFrame.sourceRectangle, Color.White);
        }

        //Tijdelijk?
        public void Fall()
        {
            jumpCommand.Execute(this, new Vector2(0, 0.001f));
        }
    }
}
