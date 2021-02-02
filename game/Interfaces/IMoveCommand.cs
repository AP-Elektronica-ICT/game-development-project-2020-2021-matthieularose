using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Interfaces
{
    public interface IMoveCommand
    {
        void Execute(ITransform transform, Vector2 direction);
        void Execute(ITransform transform, Vector2 direction, GameTime gameTime);

        void Undo();
    }
}
