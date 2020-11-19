using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Commands
{
    public class RunCommand : IMoveCommand
    {
        private Vector2 velocity;

        public RunCommand()
        {
            velocity = new Vector2(3, 0);
        }

        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= velocity;
            transform.position += direction;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
