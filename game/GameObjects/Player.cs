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

        SpriteAnimation animation;
        SpriteAnimation idleAnimation;
        SpriteAnimation runAnimation;

        private IReadInput inputReader;

        private IMoveCommand runCommand = new RunCommand();

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
            Run(direction);

            //Tijdelijk
            if (direction.X != 0)
            {
                texture = runTexture;
                animation = runAnimation;
            }
            else
            {
                texture = idleTexture;
                animation = idleAnimation;
            }
            //TODO: Bool that gives last direction the player went and transforms idle-/runsprite in that direction

            animation.Update(gameTime);
        }

        private void Run(Vector2 dir)
        {
            runCommand.Execute(this, dir);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null && animation != null) spriteBatch.Draw(texture, position, animation.currentFrame.sourceRectangle, Color.White);
        }
    }
}
