using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Animation;
using GameDevProject.Commands;
using GameDevProject.Input;
using GameDevProject.Physics;
using System.Collections.Generic;
using GameDevProject.GameObjects.World;

namespace GameDevProject.GameObjects
{
    public class Player : GameObject
    {
        Texture2D texture;
        SpriteAnimation animation;
        public IAnimationManager animationManager;

        private IReadInput inputReader;

        private Motion motion;

        public override Vector2 Position { get; set; }
        public override Rectangle CollisionRectangle { get; set; }

        public bool dead;
        public bool finishedLevel;

        public Player(IReadInput inputReader, List<Tile> gameObjects)
        {
            Position = new Vector2(350, 352);
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 38, 64);

            this.inputReader = inputReader;

            motion = new Motion(this, gameObjects);

            dead = false;
            finishedLevel = false;
        }

        public override void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            motion.Perform(gameTime, direction);

            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 38, 64);

            animationManager.Update(direction);
            texture = animationManager.texture;
            animation = animationManager.animation;

            animation.Update(gameTime);

            if (Position.Y > 450) dead = true;
            if (Position.X > 6500) finishedLevel = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, Position, animation.currentFrame.sourceRectangle, Color.White);
        }
    }
}