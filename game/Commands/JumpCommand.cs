using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Commands
{
    public class JumpCommand : IMoveCommand
    {
        private Vector2 velocity = new Vector2(0, 7);

        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= velocity;
            transform.position += direction;

            //TODO: Implement Physics - Gravity
            //TODO: Implement jumplock => player can only jump again, when he is on the ground
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
