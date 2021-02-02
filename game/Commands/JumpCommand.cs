using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Commands
{
    public class JumpCommand : IMoveCommand
    {
        private Vector2 velocity = new Vector2(0, 15);
        //private Vector2 gravity = new Vector2(0, 9.8f);

        public void Execute(ITransform transform, Vector2 direction)
        {
            throw new NotImplementedException();
        }
        public void Execute(ITransform transform, Vector2 direction, GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            transform.position -= velocity * elapsedTime;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
