using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.Input
{
    public class KeyboardInput : IReadInput
    {
        public Vector2 ReadInput()
        {
            Vector2 value = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q)) value = new Vector2(-1, 0);
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) value = new Vector2(1, 0);

            return value;
        }
    }
}
