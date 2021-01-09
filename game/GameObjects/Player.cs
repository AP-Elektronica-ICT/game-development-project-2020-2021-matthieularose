using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;
using GameDevProject.Commands;
using GameDevProject.Collision;
using GameDevProject.Physics;

namespace GameDevProject.GameObjects
{
    public class Player : IGameObject, ITransform, ICollision
    {
        Texture2D texture;
        SpriteAnimation animation;

        public bool isTouchingGround = true;
        public bool touchChange = true;

        public IAnimationManager animationManager;
        private IReadInput inputReader;
        private IMoveCommand runCommand = new RunCommand();
        private IMoveCommand jumpCommand = new JumpCommand();

        public Collider collider;

        private Gravity gravity = new Gravity();

        public Vector2 position { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public Vector2 runVelocity = new Vector2(4, 0);
        public Vector2 jumpVelocity = new Vector2(0, 10);
        public Vector2 gravVelocity = new Vector2(0, 10);
        Vector2 grav = new Vector2(0, 9.81f);

        //DateTime startTime;
        //TimeSpan timer;
        //float time;

        public Player(IReadInput reader)
        {
            inputReader = reader;

            position = new Vector2(200, 350);

            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 64);

            collider = new Collider(this);
        }

        public void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;

            

            //timer = startTime - DateTime.Now;

            var direction = inputReader.ReadInput();

            //if (direction.X != 0) runCommand.Execute(this, direction);
            //if (direction.Y != 0 && isTouchingGround)
            //{
            //    jumpCommand.Execute(this, direction, gameTime);
            //    isTouchingGround = false;
            //}

            //gravity.Pull(this, gameTime);
            if (isTouchingGround)
            {
                //startTime = DateTime.Now;
                gravVelocity = new Vector2(0, 10);
                elapsedTime = 0;
                //touchChange = !touchChange;
            }
            //else
            //{
            //    gravVelocity += grav * elapsedTime;
            //    position += gravVelocity * elapsedTime;
            //}

            if (direction.X != 0)
            {
                position += direction * runVelocity;
            }
            if (direction.Y < 0)
            {
                position += direction * jumpVelocity;
                isTouchingGround = false;
            }

            //time = (float)timer.TotalSeconds;
            //time = 0.1f;
            //if (!isTouchingGround)
            //{
            //    gravVelocity += grav * elapsedTime;
            //    position += gravVelocity * elapsedTime;
            //}

            gravVelocity += grav * elapsedTime;
            position += gravVelocity * elapsedTime;

            //Debug.WriteLine(position);

            CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 64);

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
