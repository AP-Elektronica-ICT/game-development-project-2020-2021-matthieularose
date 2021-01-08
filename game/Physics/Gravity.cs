using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    public class Gravity
    {
        private Vector2 gravity = new Vector2(0, 5);
        private Vector2 velocity = new Vector2(0, 2);
        private Vector2 acceleration = new Vector2(0, 9.8f);

        public void Pull(ITransform transform, GameTime gameTime)
        {
            int elapsedTime = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            Vector2 pull = gravity;

            //if (acceleration.Y * (elapsedTime / 100) > 9.8f) pull += acceleration * (elapsedTime / 100);
            //else pull += acceleration;
            //pull += acceleration * (elapsedTime / 10);

            transform.position += gravity;
        }
    }
}
